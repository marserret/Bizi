// Imports the Google Cloud client library
const language = require('@google-cloud/language');

// Instantiates a client
const client = new language.LanguageServiceClient();

var nom;
var prenom;
var age;
var loisir;
var dispo=[];

//Variables nécessaires pour l'identification des disponibilités
var horraire;
var jour;
var semaine = ["lundi","mardi","mercredi","jeudi","vendredi","samedi","dimanche"];
var c=0;

//Variables nécessaires pour les dispo "tous les jours sauf/exepté ..."
var full=false;
var fullam = false;
var sauf=false;
var exeption=["sauf","excepté","hormis","sans","exception","hors"];
var ok = true;

//Variables nécessaires pour l'identification des activités 
var hobies = ["guitare", "échecs", "majong","lire","pétanque"];
var hobVerb = ["jouer","joue","pratiquer", "pratique", "exercer", "exerce", "aller","vais","donner","donne","apprendre","apprend","enseigner","enseigne","aime","aimerai","faire","fais"];
var verb;
var verbText;

//Variables nécessaires pour l'identification age 
var ageNom = ["ans","automnes","balais", "berges", "piges","printemps","bougies"];

// Variables nécessaires pour identification nom + prénom
var nomVerb = ["appelle","nomme","intitule","denomme","prenomme","surnomme"];
var setPrenom = false;
var setNom = false;

//Variables nécessaires pour l'identification d'une demande 
var act;
var nb;
var heureAct;
var besoin = ["nécessite","exige","manque","désire","besoin","faut"];
var qui = ["joueurs","joueur","participants","équipier","équipiers","sportifs","sportif","musiciens","musicien","compétiteur","compétiteurs","challengeur","challengeurs","challenger","challengers"];


//Previous words
var previous;
var previousText;
var previous2;
var previous2Text;
var previous3;
var previous3Text;
var previous4;
var previous4Text;



// The text to analyze
const text = "Je vais faire une partie de pétanque avec Jacqueline cet après-midi au parc de la tête d’or. J’ai besoin de 2 joueurs mais pas trop expérimentés, juste pour s’amuser.";

const document = {
  content: text,
  type: 'PLAIN_TEXT',
};

//Detexts syntax in the document
client
  .analyzeSyntax({document: document})
  .then(results => {
    const syntax = results[0];

    console.log('Tokens:');
    syntax.tokens.forEach(part => {
      //console.log(`${part.partOfSpeech.tag}: ${part.text.content}`);
      //console.log(`Morphology:`, part.partOfSpeech);

      //Première initialisation
      //analysemot(part);

      analysebesoin(part);

      //Stockage des mots précédents (n-1, n-2, n-3 et n-4) dans la liste
      if(typeof previous3 != 'undefined'){
        previous4 = previous3;
        previous4Text = previous3Text;
      }
      if(typeof previous2 != 'undefined'){
        previous3 = previous2;
        previous3Text = previous2Text;
      }
      if(typeof previous != 'undefined'){
        previous2 = previous;
        previous2Text=previousText;
      }
      previous = part.partOfSpeech;
      previousText = part.text.content;

      //Réinitialisation de certaines variables à la fin de chaque phrase
      if(part.text.content=="."){
        sauf =false;
        full = false;
        fullam = false;
        //horraire=[];
        horraire = " ";
        c=0;
      }

    });

//Affiche le nom et le prénom 
  if(typeof prenom != 'undefined' ){
    console.log(prenom);
  }
  if(typeof nom != 'undefined'){
    console.log(nom);
  }
  //Affiche les dispo
  if(dispo.length !=0){
    console.log(dispo);
  }
  //Affichage des loisirs
  if(typeof loisir != "undefined"){
    console.log(loisir);
  }
  //Affiche l'age si il est disponible
  if(typeof age != 'undefined'){
    console.log(age);
  }

  //Affiche le nb de joueurs recherchés
  if(typeof nb !='undefined'){
    console.log(nb);
  }
  //A quelle heure ?
  if(typeof heureAct !='undefined'){
    console.log(heureAct);
  }
  //quoi ?
  if(typeof act !='undefined'){
    console.log(act);
  }

})


  .catch(err => {
    console.error('ERROR:', err);
  });

  function analysebesoin(part){
  //Utilisation (demande)
    if(part.partOfSpeech.tag == "VERB" && hobies.indexOf(part.text.content) == -1){
        verbText = part.text.content;
        verb = part.partOfSpeech;
      }

    hobVerb.forEach(function(element){
      if(verbText == element){
        hobies.forEach(function(element2){
          if(part.text.content == element2){
            if(typeof act == "undefined"){
            act = part.text.content;
            }
            else {
              act += ", " + part. text.content;
            }
          }
        })
      }
    })

    if(part.text.content == "matin"){
      heureAct = "matin";
    }
      //Après-midi
    if (part.text.content == "midi" && typeof previous!= 'undefined' && typeof previous2 != 'undefined' && !fullam){
      if(previousText=="-" && previous2Text == "après"){
        heureAct = "après-midi";
      }
    }

    if(part.partOfSpeech.tag =="NUM"){
      for (var i = 0; i < part.text.content.length; i++) {
        if(part.text.content[i].toLowerCase() =="h"){
          heureAct = part.text.content;
        }
      }
    }

    if(qui.indexOf(part.text.content) != -1 && typeof previousText != 'undefined'){
      if(previous.tag == 'NUM'){
        nb = previousText;
      }
    }
}

function analysemot(part){
    //Reconnaissance demande

    //Reconnaissance des disponibilitées (usage de après midi-soir-...)
      //"Tous les jours"
    if(part.text.content == "jours"){
      if(typeof previousText != 'undefined' && typeof previous2Text != 'undefined'){
        if(previousText == "les" && (previous2Text=="tous" || previous2Text=="Tous")){
          if(dispo.length != 0){
            semaine.forEach(function(element){
              var add = true;
              dispo.forEach(function(element2){
                if(element2.indexOf(element) != -1){
                  add = false;
                }
              })
              if(add){
                dispo.push(element);
                c++;
              }
            })
          }
          else{
            dispo.push("lundi");
            dispo.push("mardi");
            dispo.push("mercredi");
            dispo.push("jeudi");
            dispo.push("vendredi");
            dispo.push("samedi");
            dispo.push("dimanche");
            full = true;
            c+= 7;
          } 
        }
      }
    }

    //Toute la semaine 
    if(part.text.content == "semaine"){
      if(typeof previousText != 'undefined' && typeof previous2Text != 'undefined'){
        if(previousText == "la" && (previous2Text=="toute" || previous2Text=="Toute")){
          if(dispo.length != 0){
            semaine.forEach(function(element){
              var add = true;
              dispo.forEach(function(element2){
                if(element2.indexOf(element) != -1){
                  add = false;
                }
              })
              if(add){
                dispo.push(element);
                c++;
              }
            })
          }
          else{
            dispo.push("lundi");
            dispo.push("mardi");
            dispo.push("mercredi");
            dispo.push("jeudi");
            dispo.push("vendredi");
            dispo.push("samedi");
            dispo.push("dimanche");
            full = true;
            c+= 7;
          } 
        }
      }
    }

    //Matin
    if(part.text.content == "matins"){
      if(typeof previousText != 'undefined' && typeof previous2Text != 'undefined'){
        if(previousText == "les" && (previous2Text=="tous" || previous2Text=="Tous")){
          if(dispo.length != 0){
            semaine.forEach(function(element){
              var add = true;
              dispo.forEach(function(element2){
                if(element2.indexOf(element) != -1){
                  add = false;
                }
              })
              if(add){
                dispo.push(element + "matin");

                c++;
              }
            })
          }
          else{
            dispo.push("lundi matin");
            dispo.push("mardi matin");
            dispo.push("mercredi matin");
            dispo.push("jeudi matin");
            dispo.push("vendredi matin");
            dispo.push("samedi matin");
            dispo.push("dimanche matin");
            full = true;
            c+= 7;
          } 
        }
      }
    }

    //Aprèm
    if(part.text.content == "midi"){
      if(typeof previousText != 'undefined' && typeof previous2Text != 'undefined' && typeof previous3Text != 'undefined'&& typeof previous4Text != 'undefined'){
        if(previousText == "-" && previous2Text =="après" && previous3Text=="les" &&(previous4Text=="tous" || previous2Text=="Tous" ||previous4Text=="toutes" ||previous4Text=="Toutes")){
          if(dispo.length != 0){
            semaine.forEach(function(element){
              var add = true;
              dispo.forEach(function(element2){
                if(element2.indexOf(element) != -1){
                  add = false;
                }
              })
              if(add){
                dispo.push(element + "après-midi");

                c++;
              }
            })
          }
          else{
            dispo.push("lundi après-midi");
            dispo.push("mardi après-midi");
            dispo.push("mercredi après-midi");
            dispo.push("jeudi après-midi");
            dispo.push("vendredi après-midi");
            dispo.push("samedi après-midi");
            dispo.push("dimanche après-midi");
            fullam = true;
            c+= 7;
          } 
        }
      }
    }

    exeption.forEach(function(element){
      if(part.text.content == element){
        sauf=true;
      }
    })

    //Remove un jour des dispo si c'est un jour de la semaine
    semaine.forEach(function(element){
      if(sauf && part.text.content==element){
        dispo.forEach(function(element2){
          if(element2.indexOf(part.text.content) != -1){
            //Affiche l'élement retiré
            dispo.splice(dispo.indexOf(element2),1);
            c--;
          }
        })
      }
    })
    

      //Add jour par jour si on ne vient pas d'implémenter "tous les jours" dans la même phrase
    semaine.forEach(function(element){
      if(part.text.content.toLowerCase() == element && !sauf){
        dispo.forEach(function(element2){
          if(element2 == part.text.content.toLowerCase()){
            var ok=false;
          }
        })
        if(ok){
          dispo.push(part.text.content.toLowerCase());
          c++;
        }
      }
    })

    //Heure
      //Matin
    if(part.text.content == "matin"){
      horraire = "matin";
    }
      //Après-midi
    if (part.text.content == "midi" && typeof previous!= 'undefined' && typeof previous2 != 'undefined' && !fullam){
      if(previousText=="-" && previous2Text == "après"){
        horraire = "après-midi";
      }
    }

    if(part.partOfSpeech.tag =="NUM"){
      for (var i = 0; i < part.text.content.length; i++) {
        if(part.text.content[i].toLowerCase() =="h"){
          horraire = part.text.content;
        }
      }
    }

    //Ajout de l'heure en fonction du nombre de dispo que l'on vient d'ajouter
    if(c != 0 && horraire != " " && typeof horraire != 'undefined' && part.text.content != "."){
      for(var j = (dispo.length-c); j< dispo.length; j++)
      {
        dispo[j]+= " " +horraire;
      }
    }

    //Reconnaissance des activités (Problème de la première personne + compléter la liste)
    if(part.partOfSpeech.tag == "VERB" && hobies.indexOf(part.text.content) == -1){
        verbText = part.text.content;
        verb = part.partOfSpeech;
      }
      

    hobVerb.forEach(function(element){
      if(verbText == element){
        hobies.forEach(function(element2){
          if(part.text.content == element2){
            if(typeof loisir == "undefined"){
            loisir = part.text.content;
            }
            else {
              loisir +=", " + part. text.content;
            }
          }
        })
      }
    })

    //Reconnaissance de l'âge (problèmes de prev3 undefined si il existe des phrases pour donner l'age en moins de trois mots)
    ageNom.forEach(function(element){
      if(part.text.content == element && previous.tag == "NUM" ){
        if(previous2.tag =="VERB" && previous2.tense == "PRESENT" && previous2.person =="FIRST" || previous3.tag == "VERB" && previous3.person == "FIRST"){
          age = previousText;
        }
      }
    })

    //Reconnaissance du nom (problèmes de undefined undefined et testText ?) :
    if (part.partOfSpeech.proper == "PROPER" && typeof previous != 'undefined'){
      if(previous.tag == "VERB" && previous.tense == "PRESENT" && previous.person == "FIRST") {
      nomVerb.forEach(function(element){
        if(previousText == element && !setPrenom){
          prenom = part.text.content;
        //console.log('Prénom : ')
        //console.log(`${part.text.content}`);
        setPrenom = true;
        }
      }) 
      }
    }

    if(typeof previous != 'undefined'){
      if(part.partOfSpeech.proper == "PROPER" && previous.proper == "PROPER" && setPrenom && !setNom){
          nom = part.text.content;
          setNom = true;
          //console.log('Nom : ')
          //console.log(`${part.text.content}`);
      }
    }
}

function verif(){
  var answer = [];
  if(typeof age == 'undefined'){
    answer.push("Quel est votre âge ?");
  }
  if(typeof nom == 'undefined'){
    answer.push("Quel est votre nom ?")
  }
  if(typeof prenom == 'undefined'){
    answer.push("Quel est votre prénom ?")
  }
  if(typeof loisir == 'undefined'){
    answer.push("Quels sont vos loisirs ?")
  }
  if(dispo.length == 0){
    answer.push("Quelles sont vos disponibilités ?")
  }
  return answer;
}


  
  /*liste les éléments du tableau
  nomVerb.forEach(function(element){
    console.log(element);
  })
  */


  //Noms propres : part.partOfSpeech.proper = PROPER
  //Temps verbes : part.partOfSpeech.tense = ...
  //Nombre de mots : syntax.token.length
  //Index : syntax.tokens.indexOf(part) + 1 ;





