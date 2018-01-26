using Google.Cloud.Language.V1;
using System;

namespace GoogleCloudSamples
{
    public class QuickStart
    {
        public static void Main(string[] args)
        {
            string nom;
            string prenom;
            string loisir;
            string[] dispo;

            //Variables nécessaires pour l'identification des disponibilités
            string horraire;
            string jour;
            string[] semaine = new string["lundi","mardi","mercredi","jeudi","vendredi","samedi","dimanche"];
            int c=0;

            //Variables nécessaires pour les dispo "tous les jours sauf/exepté ..."
            bool full=false;
            bool fullam = false;
            bool sauf=false;
            string[] exeption=new string["sauf","excepté","hormis","sans","exception","hors"];
            bool ok = true;

            //Variables nécessaires pour l'identification des activités 
            string[] hobies =new string["guitare", "échecs", "majong","lire","pétanque"];
            string[] hobVerb =new string["jouer","joue","pratiquer", "pratique", "exercer", "exerce", "aller","vais","donner","donne","apprendre","apprend","enseigner","enseigne","aime","aimerai","faire","fais"];
            string verb;
            string verbText;

            //Variables nécessaires pour l'identification age 
            string[] ageNom =new string["ans","automnes","balais", "berges", "piges","printemps","bougies"];

            // Variables nécessaires pour identification nom + prénom
            string[] nomVerb =new string["appelle","nomme","intitule","denomme","prenomme","surnomme"];
            bool setPrenom = false;
            bool setNom = false;

            //Variables nécessaires pour l'identification d'une demande 
            string act;
            string nb;
            string heureAct;
            string[] besoin =new string["nécessite","exige","manque","désire","besoin","faut"];
            string[] qui =new string["joueurs","joueur","participants","équipier","équipiers","sportifs","sportif","musiciens","musicien","compétiteur","compétiteurs","challengeur","challengeurs","challenger","challengers"];


            //Previous words
            var previous;
            string previousText;
            var previous2;
            string previous2Text;
            var previous3;
            string previous3Text;
            var previous4;
            string previous4Text;

            //Affiche le nom et le prénom 
            if( prenom != null ){
                Console.WriteLine(prenom);
            }
            if( nom != null){
                Console.WriteLine(nom);
            }
            //Affiche les dispo
            if(dispo.length !=0){
                Console.WriteLine(dispo);
            }
            //Affichage des loisirs
            if( loisir != null){
                Console.WriteLine(loisir);
             }
            //Affiche l'age si il est disponible
            if( age != null){
                 Console.WriteLine(age);
            }

            //Affiche le nb de joueurs recherchés
            if( nb !=null){
                  Console.WriteLine(nb);
            }
            //A quelle heure ?
            if( heureAct !=null){
                  Console.WriteLine(heureAct);
            }
            //quoi ?
            if( act !=null){
                 Console.WriteLine(act);
            }

        }

        public void analysemot(var part)
        {
            //Reconnaissance demande

            //Reconnaissance des disponibilitées (usage de après midi-soir-...)
            //"Tous les jours"
            if(part.text.content == "jours"){
              if( previousText != null &&  previous2Text != null){
                if(previousText == "les" && (previous2Text=="tous" || previous2Text=="Tous")){
                  if(dispo.length != 0){
                    foreach(string[] element in semaine){
                      bool add = true;
                      foreach(string[] element2 in dispo){
                        if(element2.IndexOf(element) != -1){
                          add = false;
                        }
                      }
                      if(add){
                        dispo.Add(element);
                        c++;
                      }
                    }
                  }
                  else{
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
            if(part.text.content == "semaine"){
              if( previousText != null &&  previous2Text != null){
                if(previousText == "la" && (previous2Text=="toute" || previous2Text=="Toute")){
                  if(dispo.length != 0){
                    foreach(string[] element in semaine){
                      bool add = true;
                      foreach(string[] element2 in dispo){
                        if(element2.indexOf(element) != -1){
                          add = false;
                        }
                      }
                      if(add){
                        dispo.Add(element);
                        c++;
                      }
                    }
                  }
                  else{
                    dispo.Add("lundi");
                    dispo.Add("mardi");
                    dispo.Add("mercredi");
                    dispo.Add("jeudi");
                    dispo.Add("vendredi");
                    dispo.Add("samedi");
                    dispo.Add("dimanche");
                    full = true;
                    c+= 7;
                  } 
                }
              }
            }

            //Matin
            if(part.text.content == "matins")
            {
              if( previousText != null &&  previous2Text != null){
                if(previousText == "les" && (previous2Text=="tous" || previous2Text=="Tous")){
                  if(dispo.length != 0){
                    foreach(string[] element in semaine){
                      var add = true;
                      foreach(string[] element2 in dispo){
                        if(element2.indexOf(element) != -1){
                          add = false;
                        }
                      }
                      if(add){
                        dispo.Add(element + "matin");

                        c++;
                      }
                    }
                  }
                  else{
                    dispo.Add("lundi matin");
                    dispo.Add("mardi matin");
                    dispo.Add("mercredi matin");
                    dispo.Add("jeudi matin");
                    dispo.Add("vendredi matin");
                    dispo.Add("samedi matin");
                    dispo.Add("dimanche matin");
                    full = true;
                    c+= 7;
                  } 
                }
              }
            }

            //Aprèm
            if(part.text.content == "midi"){
              if( previousText != null &&  previous2Text != null &&  previous3Text != null&&  previous4Text != null){
                if(previousText == "-" && previous2Text =="après" && previous3Text=="les" &&(previous4Text=="tous" || previous2Text=="Tous" ||previous4Text=="toutes" ||previous4Text=="Toutes")){
                  if(dispo.length != 0){
                    foreach(string[] element in semaine){
                      bool add = true;
                      foreach(strin[] element2 in dispo){
                        if(element2.indexOf(element) != -1){
                          add = false;
                        }
                      }
                      if(add){
                        dispo.Add(element + "après-midi");

                        c++;
                      }
                    }
                  }
                  else{
                    dispo.Add("lundi après-midi");
                    dispo.Add("mardi après-midi");
                    dispo.Add("mercredi après-midi");
                    dispo.Add("jeudi après-midi");
                    dispo.Add("vendredi après-midi");
                    dispo.Add("samedi après-midi");
                    dispo.Add("dimanche après-midi");
                    fullam = true;
                    c+= 7;
                  } 
                }
              }
            }

            foreach(string[] element in exception){
              if(part.text.content == element){
                sauf=true;
              }
            }

            //Remove un jour des dispo si c'est un jour de la semaine
            foreach(string[] element in semaine){
              if(sauf && part.text.content==element){
                foreach(string[] element2 in dispo){
                  if(element2.indexOf(part.text.content) != -1){
                    //Affiche l'élement retiré
                    Array.removeAt(dispo, dispo.IndexOf(element2));
                    c--;
                  }
                }
              }
            }
            

              //Add jour par jour si on ne vient pas d'implémenter "tous les jours" dans la même phrase
            foreach(string[] element in semaine){
              if(part.text.content.ToLower() == element && !sauf){
                foreach(string [] element2 in dispo){
                  if(element2 == part.text.content.ToLower()){
                    bool ok=false;
                  }
                }
                if(ok){
                  dispo.Add(part.text.content.ToLower());
                  c++;
                }
              }
            }

            //Heure
              //Matin
            if(part.text.content == "matin"){
              horraire = "matin";
            }
              //Après-midi
            if (part.text.content == "midi" &&  previous!= null &&  previous2 != null && !fullam){
              if(previousText=="-" && previous2Text == "après"){
                horraire = "après-midi";
              }
            }

            if(part.partOfSpeech.tag =="NUM"){
              for (var i = 0; i < part.text.content.length; i++) {
                if(part.text.content[i].ToLower() =="h"){
                  horraire = part.text.content;
                }
              }
            }

            //Ajout de l'heure en fonction du nombre de dispo que l'on vient d'ajouter
            if(c != 0 && horraire != " " &&  horraire != null && part.text.content != "."){
              for(var j = (dispo.length-c); j< dispo.length; j++)
              {
                dispo[j]+= " " +horraire;
              }
            }

            //Reconnaissance des activités (Problème de la première personne + compléter la liste)
            if(part.partOfSpeech.tag == "VERB" && hobies.IndexOf(part.text.content) == -1){
                verbText = part.text.content;
                verb = part.partOfSpeech;
              }
              

            foreach(string[] element in hobVerb){
              if(verbText == element){
                foreach(string[] element2 in hobies){
                  if(part.text.content == element2){
                    if( loisir == null){
                    loisir = part.text.content;
                    }
                    else {
                      loisir +=", " + part. text.content;
                    }
                  }
                }
              }
            }

            //Reconnaissance de l'âge (problèmes de prev3 undefined si il existe des phrases pour donner l'age en moins de trois mots)
            foreach(string[] element in ageNom){
              if(part.text.content == element && previous.tag == "NUM" ){
                if(previous2.tag =="VERB" && previous2.tense == "PRESENT" && previous2.person =="FIRST" || previous3.tag == "VERB" && previous3.person == "FIRST"){
                  age = previousText;
                }
              }
            }

            //Reconnaissance du nom (problèmes de undefined undefined et testText ?) :
            if (part.partOfSpeech.proper == "PROPER" &&  previous != null){
              if(previous.tag == "VERB" && previous.tense == "PRESENT" && previous.person == "FIRST") {
              foreach(string[] element in nomVerb){
                if(previousText == element && !setPrenom){
                  prenom = part.text.content;
                //Console.WriteLine('Prénom : ')
                //Console.WriteLine(`${part.text.content}`);
                setPrenom = true;
                }
              }
              }
            }

            if( previous != null){
              if(part.partOfSpeech.proper == "PROPER" && previous.proper == "PROPER" && setPrenom && !setNom){
                  nom = part.text.content;
                  setNom = true;
                  //Console.WriteLine('Nom : ')
                  //Console.WriteLine(`${part.text.content}`);
              }
            }
        }

        //à mettre dans un while
        public string[] verif()
        {   
            bool a = true;
            string[] answer;
            if(age == null)
            {
                a = false;
                answer.Add("Quel est votre âge ?");
            }
            if( nom == null)
            {
                a=false;
                answer.Add("Quel est votre nom ?");
            }
            if( prenom == null)
            {
                a=false;
                answer.Add("Quel est votre prénom ?");
            }
            if( loisir == null)
            {
                a=false;
                answer.Add("Quels sont vos loisirs ?");
            }
            if(dispo.length == 0)
            {
                a=false;
                answer.Add("Quelles sont vos disponibilités ?");
            }
            if(a = true)
            {
                answer.Add("Votre prénom est : " + prenom);
                answer.Add("Votre nom est : " + nom);
                answer.Add("Vous avez : " + age + " ans");
                answer.Add("Vos activités sont : " + loisir);
                foreach(string[] element in dispo)
                {
                    answer.Add("Vous êtes disponible le " + element);
                }
            }
            return answer;
        }

        public void analysebesoin(var part)
        {
            //Utilisation (demande)
            if(part.partOfSpeech.tag == "VERB" && hobies.IndexOf(part.text.content) == -1)
            {
                verbText = part.text.content;
                verb = part.partOfSpeech;
            }

            foreach(string[] element in hobVerb)
            {
              if(verbText == element){
                foreach(string[] element2 in hobies)
                {
                  if(part.text.content == element2)
                  {
                    if(act == null){
                    act = part.text.content;
                    }
                    else 
                    {
                      act += ", " + part. text.content;
                    }
                  }
                }
              }
            }

            if(part.text.content == "matin")
            {
              heureAct = "matin";
            }
      //Après-midi
            if (part.text.content == "midi" &&  previous!= null &&  previous2 != null && !fullam){
              if(previousText=="-" && previous2Text == "après"){
                heureAct = "après-midi";
              }
            }

            if(part.partOfSpeech.tag =="NUM"){
              for (var i = 0; i < part.text.content.length; i++) {
                if(part.text.content[i].ToLower() =="h"){
                  heureAct = part.text.content;
                }
              }
            }

            if(qui.IndexOf(part.text.content) != -1 &&  previousText != null){
              if(previous.tag == "NUM"){
                nb = previousText;
              }
            }
        }
    }
}









