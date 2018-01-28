using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Google.Apis.Auth.OAuth2;
using Google.Cloud.Speech.V1;
using Google.Cloud.Language.V1;
using static Google.Cloud.Language.V1.AnnotateTextRequest.Types;
using Google.Protobuf.Collections;

using NAudio.Wave;

using System.Threading;
using Grpc.Auth;

using System.Speech.Synthesis;

namespace Solution
{
    public partial class Form1 : Form
    {

        private WaveInEvent waveIn = new NAudio.Wave.WaveInEvent();
        object writeLock;
        bool writeMore;
        private AudioRecorder audioRecorder = new AudioRecorder();
        string result;
        SpeechClient speech = SpeechClient.Create();
        SpeechClient.StreamingRecognizeStream streamingCall;
        RecordingState recordingState = RecordingState.RequestedStop;
        int recording_time;
        int silence;
        SpeechSynthesizer synth = new SpeechSynthesizer();

        string textUser;
        string temp;
        CancellationTokenSource cts;
        NAudio.Mixer.MixerLine mixerLine;

        string nom;
        string prenom;
        string age;
        string loisir;
        List<string> dispo = new List<string>();
        List<string> answer;

        //Variables nécessaires pour l'identification des disponibilités
        string horraire;
        string jour;
        List<string> semaine = new List<String> { "lundi", "mardi", "mercredi", "jeudi", "vendredi", "samedi", "dimanche" };
        int c = 0;

        //Variables nécessaires pour les dispo "tous les jours sauf/exepté ..."
        bool full = false;
        bool fullam = false;
        bool sauf = false;
        List<string> exception = new List<String> { "sauf", "excepté", "hormis", "sans", "exception", "hors" };
        List<int> tempo = new List<int>();
        //List<string> answer;
        bool ok = true;

        //Variables nécessaires pour l'identification des activités 
        List<string> hobies = new List<String>  { "guitare", "échecs", "mah-jong", "lire", "pétanque", "Mahjong", "mah-jong", "Mah-Jong", "Mah-jong", "mah", "Mah" };
        List<string> hobVerb = new List<String>  { "jouer", "joue", "pratiquer", "pratique", "exercer", "exerce", "aller", "vais", "donner", "donne", "apprendre", "apprend", "enseigner", "enseigne", "aime", "aimerai", "faire", "fais" };
        Token verb;
        string verbText;

        //Variables nécessaires pour l'identification age 
        List<string> ageNom = new List<String>  { "ans", "automnes", "balais", "berges", "piges", "printemps", "bougies" };

        // Variables nécessaires pour identification nom + prénom
        List<string> nomVerb = new List<String> { "appelle", "nomme", "intitule", "dénomme", "prénomme", "surnomme" };
        bool setPrenom = false;
        bool setNom = false;

        //Variables nécessaires pour l'identification d'une demande 
        string act;
        string nb;
        string heureAct;
        List<string> besoin = new List<String>{ "nécessite", "exige", "manque", "désire", "besoin", "faut" };
        List<string> qui = new List<String> { "joueurs", "joueur", "participants", "équipier", "équipiers", "sportifs", "sportif", "musiciens", "musicien", "compétiteur", "compétiteurs", "challengeur", "challengeurs", "challenger", "challengers" };


        //Previous words
        Token previous;
        string previousText;
        Token previous2;
        string previous2Text;
        Token previous3;
        string previous3Text;
        Token previous4;
        string previous4Text;


        bool pasdenomfdp;
        bool pasdeloisir;
        bool pasdeprenom;
        bool pasdage;
        bool pasdedispo;
        bool norepetitiondate;
        bool pasact;
        bool pasnb;
        bool pasheureact;

        bool initialisation;

        int wait;


        public Form1()
        {
            InitializeComponent();
            oscarEnter.Text = "";
            oscarEnter.ReadOnly = true;
            oscarEnter.BackColor = System.Drawing.SystemColors.Window;

            userRequest.Text = "";
            userRequest.ReadOnly = true;
            userRequest.BackColor = System.Drawing.SystemColors.Window;
            

            synth.SetOutputToDefaultAudioDevice();
            synth.SelectVoice("ScanSoft Virginie_Dri40_16kHz");
            synth.Rate = -5;

            temp = "";

            recording_time = 60;
            silence = 5;
            pasdenomfdp = false;
            pasdeloisir = false;
            pasdeprenom = false;
            pasdage = false;
            pasdedispo = false;
            norepetitiondate = false;
            initialisation = false;
            pasact = false;
            pasnb = false;
            pasheureact = false;

            button3.Visible = false;

            mixerLine = waveIn.GetMixerLine();

            //AnalyzeSyntaxFromText("J'exerce la pétanque");
        }

        private async Task<object> StreamingMicRecognizeAsync(CancellationTokenSource cts)
        {
            if (NAudio.Wave.WaveIn.DeviceCount < 1)
            {
                Console.WriteLine("No microphone!");
                return -1;
            }

            speech = SpeechClient.Create();
            streamingCall = speech.StreamingRecognize();

            // Write the initial request with the config.
            await streamingCall.WriteAsync(
                new StreamingRecognizeRequest()
                {
                    StreamingConfig = new StreamingRecognitionConfig()
                    {
                        Config = new RecognitionConfig()
                        {
                            Encoding =
                            RecognitionConfig.Types.AudioEncoding.Linear16,
                            SampleRateHertz = 16000,
                            LanguageCode = "fr",
                            //EnableWordTimeOffsets = true,
                            
                        },
                        InterimResults = false,
                        SingleUtterance = false,
                    }
                });


            // Print responses as they arrive.

            Task printResponses = Task.Run(async() =>
            {
               
                if (recordingState == RecordingState.Recording || recordingState == RecordingState.RequestedStop)
                {
                    while (await streamingCall.ResponseStream.MoveNext(default(CancellationToken)))
                    {
                        foreach (var result in streamingCall.ResponseStream
                                .Current.Results)
                        {
                            foreach (var alternative in result.Alternatives)
                            {
                                userRequest.Invoke((MethodInvoker)delegate { userRequest.AppendText(alternative.Transcript + "."); });
                                textUser += alternative.Transcript;
                            }
                        }
                    }
                }
               
            });

            


            // Read from the microphone and stream to API.
            writeLock = new object();
            writeMore = true;
            waveIn = new NAudio.Wave.WaveInEvent();
            waveIn.DeviceNumber = 0;
            waveIn.WaveFormat = new NAudio.Wave.WaveFormat(16000, 1);
            waveIn.DataAvailable +=
                (object sender, NAudio.Wave.WaveInEventArgs args) =>
                {
                    lock (writeLock)
                    {
                        if (!writeMore) return;
                        streamingCall.WriteAsync(
                            new StreamingRecognizeRequest()
                            {
                                AudioContent = Google.Protobuf.ByteString
                                    .CopyFrom(args.Buffer, 0, args.BytesRecorded)
                            }).Wait();
                    }
                    
                };

            waveIn.StartRecording();

            await Task.Delay(TimeSpan.FromSeconds(60));
            // Stop recording and shut down.
            waveIn.StopRecording();
            lock (writeLock) writeMore = false;
            await streamingCall.WriteCompleteAsync();
            await printResponses;

            /*if(recordingState != RecordingState.RequestedStop)
            {
                Task me = StreamingMicRecognizeAsync(cts);
                recordingState = RecordingState.Recording;
                writeMore = true;
                recording_time = 65;
                timer1.Start();
            }*/
               
            return 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (recordingState == RecordingState.RequestedStop)
           {
                cts = new CancellationTokenSource();
                textUser = "";
                oscarEnter.Text = "“Bonjour, je m’appelle Oscar. Je suis un système créé pour améliorer votre quotidien. Pour effectuer mon initialisation, j’aurais besoin que vous vous présentiez en m’indiquant votre prénom, votre nom, votre âge, vos loisirs, ainsi que vos disponibilités”";
                synth.Speak(oscarEnter.Text);
                Task me = StreamingMicRecognizeAsync(cts);
                recordingState = RecordingState.Recording;
                writeMore = true;
                timer1.Start();
                button1.Visible = false;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cts != null)
            {
                cts.Cancel();
                waveIn.StopRecording();
                writeMore = false;
                recordingState = RecordingState.RequestedStop;
                timer1.Stop();
                recording_time = 60;
                label2.Text = recording_time.ToString();
                button2.Enabled = false;

                AnalyzeSyntaxFromText(textUser);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            recording_time--;
            label2.Text = recording_time.ToString();

            if (recording_time == 0)
            {
                cts.Cancel();
                waveIn.StopRecording();
                writeMore = false;
                recordingState = RecordingState.RequestedStop;
                timer1.Stop();
                recording_time = 60;
                label2.Text = recording_time.ToString();
            }
        }

        private void AnalyzeSyntaxFromText(string text)
        {
            var client = LanguageServiceClient.Create();
            var response = client.AnnotateText(new Document()
            {
                Content = text,
                Type = Document.Types.Type.PlainText
            },
            new Features() { ExtractSyntax = true });

            WriteSentences(response.Sentences, response.Tokens);
        }

        private void WriteSentences(IEnumerable<Sentence> sentences,
            RepeatedField<Token> tokens)
        {

            foreach (var sentence in sentences)
            {
                Console.WriteLine($"\t{sentence.Text.BeginOffset}: {sentence.Text.Content}");
            }


            foreach (var token in tokens)
            {

                //textBox1.Text += ($"\t{token.PartOfSpeech.Tag} "
                //+ $"{token.Text.Content}");

                //Analyse du mot
                if (!initialisation)
                {
                    if (!pasdenomfdp && !pasdeloisir && !pasdage && !pasdedispo && !pasdeprenom)
                    {
                        Analysemot(token);
                    }

                    if (pasdenomfdp)
                    {
                        chercheNom(tokens[tokens.Count - 1]);
                        pasdenomfdp = false;
                    }

                    if (pasdeloisir)
                    {
                        chercheDispo(token);
                        pasdeloisir = false;
                    }

                    if (pasdage)
                    {
                        chercheAge(tokens[tokens.Count - 2]);
                        pasdage = false;
                    }

                    if (pasdedispo)
                    {
                        chercheDispo(token);
                        pasdedispo = false;
                    }

                    if (pasdeprenom)
                    {
                        cherchePrenom(tokens[tokens.Count - 1]);
                        pasdeprenom = false;
                    }

                    if (prenom != null && nom != null && age != null && loisir != null && dispo.Count() != 0)
                    {
                        if (tokens[0].Text.Content == "non")
                        {
                            nom = null;
                            prenom = null;
                            age = null;
                            loisir = null;
                            dispo.Clear();
                            prenomTB.Text = "";
                            nomTB.Text = "";
                            ageTB.Text = "";
                            loisirTB.Text = "";
                            dispoTB.Text = "";
                        }

                        if (tokens[0].Text.Content == "oui")
                        {
                            cts.Cancel();
                            waveIn.StopRecording();
                            writeMore = false;
                            recordingState = RecordingState.RequestedStop;
                            timer1.Stop();
                            oscarEnter.Text = "";
                            userRequest.Text = "";
                            label2.Text = "60";
                            recording_time = 60;
                            label2.Text = recording_time.ToString();
                            button3.Visible = true;
                            initialisation = true;
                            return;
                        }
                    }
                }
                if (initialisation)
                {
                    if (!pasheureact && !pasnb && !pasact)
                    {
                        button3.Enabled = false;
                        analysebesoin(token);
                    }
                    if (pasact)
                    {
                        button3.Enabled = false;
                        chercheAct(tokens[tokens.Count - 1]);
                        pasact = false;
                    }
                    if (pasnb)
                    {
                        button3.Enabled = false;
                        chercheNb(tokens[tokens.Count - 1]);
                        pasnb = false;
                    }
                    if (pasheureact)
                    {
                        button3.Enabled = false;
                        chercheHeureAct(tokens[tokens.Count - 1]);
                        pasheureact = false;
                    }

                    if(act != null && nb != null && heureAct != null)
                    {
                        button3.Enabled = false;
                        oscarEnter.Text = "Une partie de " + act + " est organisée à " + heureAct + " et il vous faut " + nb + " joueur(s).";
                        userRequest.Text = "";

                        wait = 2;
                        timer3.Start();

                    }

                }
                //Ajouter à la fin dans la boucle : foreach token in token
                //Stockage des mots précédents (n-1, n-2, n-3 et n-4) dans la liste
                if (previous3 != null)
                {
                    previous4 = previous3;
                    previous4Text = previous3Text;
                }
                if (previous2 != null)
                {
                    previous3 = previous2;
                    previous3Text = previous2Text;
                }
                if (previous != null)
                {
                    previous2 = previous;
                    previous2Text = previousText;
                }
                previous = token;
                previousText = token.Text.Content;

                //Réinitialisation de certaines variables à la fin de chaque phrase
                if (token.Text.Content == ".")
                {
                    sauf = false;
                    full = false;
                    fullam = false;
                    tempo.Clear();
                    //horraire=[];
                    horraire = " ";
                    c = 0;
                }

            }
            
            
            //Affiche le nom et le prénom 
            if (prenom != null)
            {
                prenomTB.Text = prenom;
            }

            if (nom != null)
            {
                nomTB.Text = nom;
            }
            //Affiche les dispo
            if (dispo.Count() != 0 && !norepetitiondate)
            {
                foreach(string item in dispo)
                {
                    dispoTB.Text += item+"\r\n";
                }

                norepetitiondate = true;
                
            }
            //Affichage des loisirs
            if (loisir != null)
            {
                loisirTB.Text = loisir;
            }
            //Affiche l'age si il est disponible
            if (age != null)
            {
                ageTB.Text = age;
            }

            //Affiche le nb de joueurs recherchés
            if (nb != null)
            {
                nbTB.Text = nb;
            }
            //A quelle heure ?
            if (heureAct != null)
            {
                heureActTB.Text = heureAct;
            }
            //quoi ?
            if (act != null)
            {
                actTB.Text = act;

            }

            if (!initialisation)
                Verif();

            if (initialisation)
                VerifBesoin();
        }
       
        public void Analysemot(Token part)
        {
            //Reconnaissance demande

            //Reconnaissance des disponibilitées (usage de après midi-soir-...)
            //"Tous les jours"
            if (part.Text.Content == "jours")
            {
                if (previousText != null && previous2Text != null)
                {
                    if (previousText == "les" && (previous2Text == "tous" || previous2Text == "Tous"))
                    {
                        if (dispo.Count != 0)
                        {
                            foreach (string element in semaine)
                            {
                                bool add = true;
                                foreach (string element2 in dispo)
                                {
                                    if (element2.IndexOf(element) != -1)
                                    {
                                        add = false;
                                    }
                                }
                                if (add)
                                {
                                    dispo.Add(element);
                                    c++;
                                }
                            }
                        }
                        else
                        {
                            dispo.Add("lundi");
                            dispo.Add("mardi");
                            dispo.Add("mercredi");
                            dispo.Add("jeudi");
                            dispo.Add("vendredi");
                            dispo.Add("samedi");
                            dispo.Add("dimanche");
                            full = true;
                            c += 7;
                        }
                    }
                }
            }

            //Toute la semaine 
            if (part.Text.Content == "semaine")
            {
                if (previousText != null && previous2Text != null)
                {
                    if (previousText == "la" && (previous2Text == "toute" || previous2Text == "Toute"))
                    {
                        if (dispo.Count != 0)
                        {
                            foreach (string element in semaine)
                            {
                                bool add = true;
                                foreach (string element2 in dispo)
                                {
                                    if (element2.IndexOf(element) != -1)
                                    {
                                        add = false;
                                    }
                                }
                                if (add)
                                {
                                    dispo.Add(element);
                                    c++;
                                }
                            }
                        }
                        else
                        {
                            dispo.Add("lundi");
                            dispo.Add("mardi");
                            dispo.Add("mercredi");
                            dispo.Add("jeudi");
                            dispo.Add("vendredi");
                            dispo.Add("samedi");
                            dispo.Add("dimanche");
                            full = true;
                            c += 7;
                        }
                    }
                }
            }

            //Matin
            if (part.Text.Content == "matins")
            {
                if (previousText != null && previous2Text != null)
                {
                    if (previousText == "les" && (previous2Text == "tous" || previous2Text == "Tous"))
                    {
                        if (dispo.Count != 0)
                        {
                            foreach (string element in semaine)
                            {
                                var add = true;
                                foreach (string element2 in dispo)
                                {
                                    if (element2.IndexOf(element) != -1)
                                    {
                                        add = false;
                                    }
                                }
                                if (add)
                                {
                                    dispo.Add(element + "matin");

                                    c++;
                                }
                            }
                        }
                        else
                        {
                            dispo.Add("lundi matin");
                            dispo.Add("mardi matin");
                            dispo.Add("mercredi matin");
                            dispo.Add("jeudi matin");
                            dispo.Add("vendredi matin");
                            dispo.Add("samedi matin");
                            dispo.Add("dimanche matin");
                            full = true;
                            c += 7;
                        }
                    }
                }
            }

            //Aprèm
            if (part.Text.Content == "midi")
            {
                if (previousText != null && previous2Text != null && previous3Text != null && previous4Text != null)
                {
                    if (previousText == "-" && previous2Text == "après" && previous3Text == "les" && (previous4Text == "tous" || previous2Text == "Tous" || previous4Text == "toutes" || previous4Text == "Toutes"))
                    {
                        if (dispo.Count != 0)
                        {
                            foreach (string element in semaine)
                            {
                                bool add = true;
                                foreach (string element2 in dispo)
                                {
                                    if (element2.IndexOf(element) != -1)
                                    {
                                        add = false;
                                    }
                                }
                                if (add)
                                {
                                    dispo.Add(element + "après-midi");

                                    c++;
                                }
                            }
                        }
                        else
                        {
                            dispo.Add("lundi après-midi");
                            dispo.Add("mardi après-midi");
                            dispo.Add("mercredi après-midi");
                            dispo.Add("jeudi après-midi");
                            dispo.Add("vendredi après-midi");
                            dispo.Add("samedi après-midi");
                            dispo.Add("dimanche après-midi");
                            fullam = true;
                            c += 7;
                        }
                    }
                }
            }

            foreach (string element in exception)
            {
                if (part.Text.Content == element)
                {
                    sauf = true;
                }
            }

            //Remove un jour des dispo si c'est un jour de la semaine
            foreach (string element in semaine)
            {
                if (sauf && part.Text.Content == element)
                {
                    foreach (string element2 in dispo)
                    {
                        if (element2.IndexOf(part.Text.Content) != -1)
                        {
                            tempo.Add(dispo.IndexOf(element2));
                            c--;
                        }
                    }
                }
            }
            if (sauf)
            {
                tempo.Sort();
                tempo.Reverse();
                if (dispo.Count != 0)
                {
                    foreach (int element in tempo)
                    {
                        dispo.RemoveAt(element);
                    }
                    tempo.Clear();
                }
            }


            //Add jour par jour si on ne vient pas d'implémenter "tous les jours" dans la même phrase
            foreach (string element in semaine)
            {
                if (part.Text.Content.ToLower() == element && !sauf)
                {
                        foreach (string element2 in dispo)
                        {
                            if (element2 == part.Text.Content.ToLower())
                            {
                                bool ok = false;
                            }
                        }
                        if (ok)
                        {
                            dispo.Add(part.Text.Content.ToLower());
                            c++;
                        }
                    
                }
            }

            //Heure
            //Matin
            if (part.Text.Content == "matin")
            {
                horraire = "matin";
            }
            //Après-midi
            if (part.Text.Content == "midi" && previous != null && previous2 != null && !fullam)
            {
                if (previousText == "-" && previous2Text == "après")
                {
                    horraire = "après-midi";
                }
            }

            if ($"{part.PartOfSpeech.Tag}" == "Num")
            {

                for (var i = 0; i < part.Text.Content.Length; i++)
                {
                    
                    if (part.Text.Content[i] == 'h')
                    {
                        horraire = part.Text.Content;
                    }
                }
            }

            //Ajout de l'heure en fonction du nombre de dispo que l'on vient d'ajouter
            if (c != 0 && horraire != " " && horraire != null)
            {
                for (var j = (dispo.Count - c); j < dispo.Count; j++)
                {
                    dispo[j] += " " + horraire;
                }
                horraire = " ";
            }

            //Reconnaissance des activités (Problème de la première personne + compléter la liste)
            if ($"{part.PartOfSpeech.Tag}" == "Verb" && hobies.IndexOf(part.Text.Content) == -1)
            {
                verbText = part.Text.Content;
                // verb = part.PartOfSpeech;

            }


            foreach (string element in hobVerb)
            {
                if (verbText == element)
                {
                    foreach (string element2 in hobies)
                    {
                        if (part.Text.Content == element2)
                        {
                            if (loisir == null)
                            {
                                loisir = part.Text.Content;
                            }
                            else
                            {
                                loisir += ", " + part.Text.Content;
                            }
                        }
                    }
                }
            }

            //Reconnaissance de l'âge (problèmes de prev3 undefined si il existe des phrases pour donner l'age en moins de trois mots)
            foreach (string element in ageNom)
            {
                if (part.Text.Content == element && $"{previous.PartOfSpeech.Tag}" == "Num")
                {
                    if ($"{previous2.PartOfSpeech.Tag}" == "Verb" && $"{previous2.PartOfSpeech.Tense}" == "Present" && $"{previous2.PartOfSpeech.Person}" == "First" || $"{previous3.PartOfSpeech.Tag}" == "Verb" && $"{previous3.PartOfSpeech.Person}" == "First")
                    {
                        age = previousText;
                    }
                }
            }

            //Reconnaissance du nom (problèmes de undefined undefined et testText ?) :
            if ($"{part.PartOfSpeech.Proper}" == "Proper" && previous != null && previous2 != null && previous3 != null)
            {
                foreach (string element in nomVerb)
                {
                    if (previousText == element && !setPrenom)
                    {
                        if ((previous2Text == "m'" || previous2Text == "me" || previous2Text == "nom" || previous2Text=="prénom") && (previous3Text.ToLower() == "je" || previousText.ToLower() == "mon"))
                        {
                            prenom = part.Text.Content;
                            //Console.WriteLine('Prénom : ')
                            //Console.WriteLine(`${part.text.content}`);
                            setPrenom = true;
                        }
                    }
                } 
            }

            //Cas particulier
            if ($"{part.PartOfSpeech.Proper}" == "Proper" && previous != null && previous2 != null)
            {
                if (previousText == "m'appelle")
                {
                    prenom = part.Text.Content;
                    setPrenom = true;
                }
            }



                if (previous != null)
            {
                if ($"{part.PartOfSpeech.Proper}" == "Proper" && $"{previous.PartOfSpeech.Proper}" == "Proper" && setPrenom && !setNom)
                {
                    nom = part.Text.Content;
                    setNom = true;
                    //Console.WriteLine('Nom : ')
                    //Console.WriteLine(`${part.text.content}`);
                }
            }
        }

        public void analysebesoin(Token part)
        {
            //Utilisation (demande)
            if ($"{part.PartOfSpeech.Tag}" == "Verb" && hobies.IndexOf(part.Text.Content) == -1)
            {
                verbText = part.Text.Content;
                verb = part;
            }

            foreach (string element in hobVerb)
            {
                if (verbText == element)
                {
                    foreach (string element2 in hobies)
                    {
                        if (part.Text.Content == element2)
                        {
                            if (act == null)
                            {
                                act = part.Text.Content;
                            }
                            else
                            {
                                act += ", " + part.Text.Content;
                            }
                        }
                    }
                }
            }

            if (part.Text.Content == "matin")
            {
                heureAct = "matin";
            }
            //Après-midi
            if (part.Text.Content == "midi" && previous != null && previous2 != null && !fullam)
            {
                if (previousText == "-" && previous2Text == "après")
                {
                    heureAct = "après-midi";
                }
            }

            if ($"{part.PartOfSpeech.Tag}" == "Num")
            {
                for (var i = 0; i < part.Text.Content.Length; i++)
                {
                   if (part.Text.Content[i] == 'h')
                    {
                        heureAct = part.Text.Content;
                    }
                    
                }
            }

            if (qui.IndexOf(part.Text.Content) != -1 && previousText != null)
            {
                if ($"{previous.PartOfSpeech.Tag}" == "Num")
                {
                    nb = previousText;
                }
            }
        }

        private void chercheAct(Token part)
        {
            act = part.Text.Content;
        }

        private void chercheNb(Token part)
        {
            nb = part.Text.Content;
        }

        private void chercheHeureAct(Token part)
        {
            heureAct = part.Text.Content;
        }

        private void VerifBesoin()
        {
           if(act == null)
            {
                pasact = true;
                oscarEnter.Text = "Que voulez-vous faire ?";
                synth.Speak("Que voulez-vous faire ?");
                userRequest.Text = "";
                textUser = "";
                Task me = StreamingMicRecognizeAsync(cts);
                recordingState = RecordingState.Recording;
                writeMore = true;
                timer1.Start();
                button2.Enabled = true;
                return;
            }
            if (nb == null)
            {
                pasnb = true;
                oscarEnter.Text = "De combiens de joueurs avez-vous besoin ?";
                synth.Speak("De combiens de joueurs avez-vous besoin ?");
                userRequest.Text = "";
                textUser = "";
                Task me = StreamingMicRecognizeAsync(cts);
                recordingState = RecordingState.Recording;
                writeMore = true;
                timer1.Start();
                button2.Enabled = true;
                return;
            }
            if (heureAct == null)
            {
                pasheureact = true;
                oscarEnter.Text = "A quelle heure voulez-vous réaliser votre activité ?";
                synth.Speak("A quelle heure voulez-vous réaliser votre activité ?");
                userRequest.Text = "";
                textUser = "";
                Task me = StreamingMicRecognizeAsync(cts);
                recordingState = RecordingState.Recording;
                writeMore = true;
                timer1.Start();
                button2.Enabled = true;
                return;
            }

        }

        private void  Verif()
        {
            if (prenom == null)
            {
                pasdeprenom = true;
                oscarEnter.Text = "Quel est votre prénom ?";
                synth.Speak("Quel est votre prénom ?");
                userRequest.Text = "";
                textUser = "";
                Task me = StreamingMicRecognizeAsync(cts);
                recordingState = RecordingState.Recording;
                writeMore = true;
                timer1.Start();
                button2.Enabled = true;
                return;
            }

            if (nom == null)
            {
                pasdenomfdp = true;
                oscarEnter.Text = "Quel est votre nom ?";
                synth.Speak("Quel est votre nom ?");
                userRequest.Text = "";
                textUser = "";
                Task me = StreamingMicRecognizeAsync(cts);
                recordingState = RecordingState.Recording;
                writeMore = true;
                timer1.Start();
                button2.Enabled = true;
                return;

            }

            if (age == null)
            {
                pasdage = true;
                oscarEnter.Text = "Quel est votre âge ?";
                synth.Speak("Quel est votre âge ?");
                userRequest.Text = "";
                textUser = "";
                Task me = StreamingMicRecognizeAsync(cts);
                recordingState = RecordingState.Recording;
                writeMore = true;
                timer1.Start();
                button2.Enabled = true;
                return;

            }

            if (loisir == null)
            {
                pasdeloisir = true;
                oscarEnter.Text = "Quels sont vos loisirs ?";
                synth.Speak("Quels sont vos loisirs ?");
                userRequest.Text = "";
                textUser = "";
                Task me = StreamingMicRecognizeAsync(cts);
                recordingState = RecordingState.Recording;
                writeMore = true;
                timer1.Start();
                button2.Enabled = true;
                return;
            }

            if (dispo.Count == 0)
            {
                pasdedispo = true;
                oscarEnter.Text = "Quel sont vos disponibilités ?";
                synth.Speak("Quel sont vos disponibilités ?");
                userRequest.Text = "";
                textUser = "";
                Task me = StreamingMicRecognizeAsync(cts);
                recordingState = RecordingState.Recording;
                writeMore = true;
                timer1.Start();
                button2.Enabled = true;
                return;
            }

            if(dispo.Count != 0 && loisir != null && age != null && prenom != null && nom != null)
            {
                button2.Enabled = false;
                if (cts != null)
                {
                    cts.Cancel();
                    waveIn.StopRecording();
                    writeMore = false;
                    recordingState = RecordingState.RequestedStop;
                    timer1.Stop();
                    recording_time = 60;
                    label2.Text = recording_time.ToString();
                }

                oscarEnter.Text = "";
                userRequest.Text = "";
                cts.Cancel();
                waveIn.StopRecording();

                synth.Speak("J'ai toutes les informations souhaitées. Nous allons maintenant les contrôler");
                synth.Speak("Veuillez contrôler les informations suivantes et, dites oui si elles sont correctes, ou , non si elles sont erronées");

                oscarEnter.Text = "Vous vous appelez " + prenom + " " + nom + ", vous avez " + age + " ans et vous aimez : " + loisir + ". Vos disponibilités : ";
                foreach(string date in dispo)
                {
                    oscarEnter.Text += (date + " ; ");
                }

                wait = 2;
                timer2.Start();

                return;
            }
           
        }

        private void chercheNom(Token part)
        {
            
            nom = part.Text.Content;
        }

        private void chercheDispo(Token part)
        {
            //Reconnaissance des disponibilitées (usage de après midi-soir-...)
            //"Tous les jours"
            if (part.Text.Content == "jours")
            {
                if (previousText != null && previous2Text != null)
                {
                    if (previousText == "les" && (previous2Text == "tous" || previous2Text == "Tous"))
                    {
                        if (dispo.Count != 0)
                        {
                            foreach (string element in semaine)
                            {
                                bool add = true;
                                foreach (string element2 in dispo)
                                {
                                    if (element2.IndexOf(element) != -1)
                                    {
                                        add = false;
                                    }
                                }
                                if (add)
                                {
                                    dispo.Add(element);
                                    c++;
                                }
                            }
                        }
                        else
                        {
                            dispo.Add("lundi");
                            dispo.Add("mardi");
                            dispo.Add("mercredi");
                            dispo.Add("jeudi");
                            dispo.Add("vendredi");
                            dispo.Add("samedi");
                            dispo.Add("dimanche");
                            full = true;
                            c += 7;
                        }
                    }
                }
            }

            //Toute la semaine 
            if (part.Text.Content == "semaine")
            {
                if (previousText != null && previous2Text != null)
                {
                    if (previousText == "la" && (previous2Text == "toute" || previous2Text == "Toute"))
                    {
                        if (dispo.Count != 0)
                        {
                            foreach (string element in semaine)
                            {
                                bool add = true;
                                foreach (string element2 in dispo)
                                {
                                    if (element2.IndexOf(element) != -1)
                                    {
                                        add = false;
                                    }
                                }
                                if (add)
                                {
                                    dispo.Add(element);
                                    c++;
                                }
                            }
                        }
                        else
                        {
                            dispo.Add("lundi");
                            dispo.Add("mardi");
                            dispo.Add("mercredi");
                            dispo.Add("jeudi");
                            dispo.Add("vendredi");
                            dispo.Add("samedi");
                            dispo.Add("dimanche");
                            full = true;
                            c += 7;
                        }
                    }
                }
            }

            //Matin
            if (part.Text.Content == "matins")
            {
                if (previousText != null && previous2Text != null)
                {
                    if (previousText == "les" && (previous2Text == "tous" || previous2Text == "Tous"))
                    {
                        if (dispo.Count != 0)
                        {
                            foreach (string element in semaine)
                            {
                                var add = true;
                                foreach (string element2 in dispo)
                                {
                                    if (element2.IndexOf(element) != -1)
                                    {
                                        add = false;
                                    }
                                }
                                if (add)
                                {
                                    dispo.Add(element + "matin");

                                    c++;
                                }
                            }
                        }
                        else
                        {
                            dispo.Add("lundi matin");
                            dispo.Add("mardi matin");
                            dispo.Add("mercredi matin");
                            dispo.Add("jeudi matin");
                            dispo.Add("vendredi matin");
                            dispo.Add("samedi matin");
                            dispo.Add("dimanche matin");
                            full = true;
                            c += 7;
                        }
                    }
                }
            }

            //Aprèm
            if (part.Text.Content == "midi")
            {
                if (previousText != null && previous2Text != null && previous3Text != null && previous4Text != null)
                {
                    if (previousText == "-" && previous2Text == "après" && previous3Text == "les" && (previous4Text == "tous" || previous2Text == "Tous" || previous4Text == "toutes" || previous4Text == "Toutes"))
                    {
                        if (dispo.Count != 0)
                        {
                            foreach (string element in semaine)
                            {
                                bool add = true;
                                foreach (string element2 in dispo)
                                {
                                    if (element2.IndexOf(element) != -1)
                                    {
                                        add = false;
                                    }
                                }
                                if (add)
                                {
                                    dispo.Add(element + "après-midi");

                                    c++;
                                }
                            }
                        }
                        else
                        {
                            dispo.Add("lundi après-midi");
                            dispo.Add("mardi après-midi");
                            dispo.Add("mercredi après-midi");
                            dispo.Add("jeudi après-midi");
                            dispo.Add("vendredi après-midi");
                            dispo.Add("samedi après-midi");
                            dispo.Add("dimanche après-midi");
                            fullam = true;
                            c += 7;
                        }
                    }
                }
            }

            foreach (string element in exception)
            {
                if (part.Text.Content == element)
                {
                    sauf = true;
                }
            }

            //Remove un jour des dispo si c'est un jour de la semaine
            foreach (string element in semaine)
            {
                if (sauf && part.Text.Content == element)
                {
                    foreach (string element2 in dispo)
                    {
                        if (element2.IndexOf(part.Text.Content) != -1)
                        {
                            tempo.Add(dispo.IndexOf(element2));

                            c--;
                        }
                    }
                }
            }
            if (sauf)
            {
                tempo.Sort();
                tempo.Reverse();
                foreach (int element in tempo)
                {
                    dispo.RemoveAt(element);
                }
            }


            //Add jour par jour si on ne vient pas d'implémenter "tous les jours" dans la même phrase
            foreach (string element in semaine)
            {
                if (part.Text.Content.ToLower() == element && !sauf)
                {
                    foreach (string element2 in dispo)
                    {
                        if (element2 == part.Text.Content.ToLower())
                        {
                            bool ok = false;
                        }
                    }
                    if (ok)
                    {
                        dispo.Add(part.Text.Content.ToLower());
                        c++;
                    }

                }
            }

            //Heure
            //Matin
            if (part.Text.Content == "matin")
            {
                horraire = "matin";
            }
            //Après-midi
            if (part.Text.Content == "midi" && previous != null && previous2 != null && !fullam)
            {
                if (previousText == "-" && previous2Text == "après")
                {
                    horraire = "après-midi";
                }
            }

            if ($"{part.PartOfSpeech.Tag}" == "Num")
            {

                for (var i = 0; i < part.Text.Content.Length; i++)
                {

                    if (part.Text.Content[i] == 'h')
                    {
                        horraire = part.Text.Content;

                    }
                }
            }

            //Ajout de l'heure en fonction du nombre de dispo que l'on vient d'ajouter
            if (c != 0 && horraire != " " && horraire != null)
            {
                for (var j = (dispo.Count - c); j < dispo.Count; j++)
                {
                    dispo[j] += " " + horraire;
                }
                horraire = " ";
            }
        }

        private void chercheAge(Token part)
        {
            //Reconnaissance de l'âge (problèmes de prev3 undefined si il existe des phrases pour donner l'age en moins de trois mots)
                    age = part.Text.Content;
        }

        private void cherchePrenom(Token part)
        {
            prenom = part.Text.Content;
        }

        private void chercheLoisir(Token part)
        { 
            foreach (string element2 in hobies)
            {
                if (part.Text.Content == element2)
                {
                    if (loisir == null)
                    {
                        loisir = part.Text.Content;
                    }
                    else
                    {
                        loisir += ", " + part.Text.Content;
                    }
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            wait --;
            if(wait == 0)
            {
                if (recordingState == RecordingState.RequestedStop)
                {
                    cts = new CancellationTokenSource();
                    textUser = "";
                }

                    timer2.Stop();
                synth.Speak(oscarEnter.Text);
                
                userRequest.Text = "";
                textUser = "";

                Task me = StreamingMicRecognizeAsync(cts);
                recordingState = RecordingState.Recording;
                writeMore = true;
                timer1.Start();
                button2.Enabled = true;
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;
            button2.Enabled = true;
            cts = new CancellationTokenSource();
            textUser = "";
            userRequest.Text = "";
            oscarEnter.Text = "“Que puis-je faire pour vous ?”";
            synth.Speak(oscarEnter.Text);
            Task me = StreamingMicRecognizeAsync(cts);
            recordingState = RecordingState.Recording;
            writeMore = true;
            timer1.Start();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            wait--;
            if (wait == 0)
            {
                timer3.Stop();
                synth.Speak(oscarEnter.Text);

                userRequest.Text = "";
                textUser = "";
            }
        }

    }
}
