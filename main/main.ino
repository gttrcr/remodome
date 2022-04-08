#define POS_PARK /*****************/ 227
#define POS_EST /******************/ 101
#define POS_OVEST /****************/ 334
#define POS_NORD /*****************/ 450
#define ON /***********************/ 0
#define OFF /**********************/ 1
#define DESTRA /*******************/ 3
#define SINISTRA /*****************/ 4
#define VELOCITA /*****************/ 5
#define APRI_CUPOLA /**************/ 6
#define CHIUDI_CUPOLA /************/ 7
#define RELAIS_MONTATURA /*********/ 8
#define RELAIS_GPS /***************/ 9
#define PANNELLO_ON /**************/ 10
#define PANNELLO_OFF /*************/ 11
#define ESCLUSIONE_PIOGGIA /*******/ 13

#define OVEST /********************/ 23
#define EST /**********************/ 25
#define NORD /*********************/ 41
#define IMPULSI /******************/ 27
#define HOMING /*******************/ 29
#define CUPOLA_CHIUSA /************/ 31
#define CUPOLA_APERTA /************/ 33
#define SENSORE_PIOGGIA /**********/ 35
#define STATO_SELETTORE_PIOGGIA /**/ 37
#define STATO_PANNELLO /***********/ 39

void setup()
{
  Serial.begin(9600);

  pinMode(DESTRA, OUTPUT);
  pinMode(SINISTRA, OUTPUT);
  pinMode(VELOCITA, OUTPUT);
  pinMode(APRI_CUPOLA, OUTPUT);
  pinMode(CHIUDI_CUPOLA, OUTPUT);
  pinMode(RELAIS_MONTATURA, OUTPUT);
  pinMode(RELAIS_GPS, OUTPUT);
  pinMode(PANNELLO_ON, OUTPUT);
  pinMode(PANNELLO_OFF, OUTPUT);
  pinMode(ESCLUSIONE_PIOGGIA, OUTPUT);

  pinMode(HOMING, INPUT);
  pinMode(IMPULSI, INPUT);
  pinMode(CUPOLA_APERTA, INPUT);
  pinMode(CUPOLA_CHIUSA, INPUT);
  pinMode(EST, INPUT);
  pinMode(OVEST, INPUT);
  pinMode(NORD, INPUT);
  pinMode(SENSORE_PIOGGIA, INPUT);
  pinMode(STATO_SELETTORE_PIOGGIA, INPUT);
  pinMode(STATO_PANNELLO, INPUT);

  digitalWrite(HOMING, OFF);
  digitalWrite(DESTRA, OFF);
  digitalWrite(SINISTRA, OFF);
  digitalWrite(VELOCITA, OFF);
  digitalWrite(APRI_CUPOLA, OFF);
  digitalWrite(CHIUDI_CUPOLA, OFF);
  digitalWrite(RELAIS_MONTATURA, OFF);
  digitalWrite(RELAIS_GPS, OFF);
  digitalWrite(IMPULSI, OFF);
  digitalWrite(CUPOLA_APERTA, OFF);
  digitalWrite(CUPOLA_CHIUSA, OFF);
  digitalWrite(EST, OFF);
  digitalWrite(OVEST, OFF);
  digitalWrite(NORD, OFF);
  digitalWrite(SENSORE_PIOGGIA, OFF);
  digitalWrite(PANNELLO_ON, OFF);
  digitalWrite(PANNELLO_OFF, OFF);
  digitalWrite(ESCLUSIONE_PIOGGIA, OFF);
  digitalWrite(STATO_SELETTORE_PIOGGIA, OFF);
  digitalWrite(STATO_PANNELLO, OFF);
}

int piedi = POS_PARK, dir, tempo = 1000;
byte currentState = 0;
byte previousState = 0;
// bool apply = true;

// LETTERE UTILIZZATE: D d S s T t F V v C c A G g P B Q R I E X K

void loop()
{
  switch (Serial.read())
  {
    // apply = true;

  // Destra
  case 'D':
    dir = 1;
    digitalWrite(DESTRA, ON);
    digitalWrite(SINISTRA, OFF);
    break;

  // Destra temporizzato
  case 'd':
    dir = 0;
    digitalWrite(DESTRA, ON);
    digitalWrite(SINISTRA, OFF);
    delay(tempo);
    digitalWrite(DESTRA, OFF);
    digitalWrite(SINISTRA, OFF);
    // apply = false;
    break;

  // Sinistra
  case 'S':
    dir = -1;
    digitalWrite(DESTRA, OFF);
    digitalWrite(SINISTRA, ON);
    break;

  // Sinistra temporizzato
  case 's':
    dir = 0;
    digitalWrite(DESTRA, OFF);
    digitalWrite(SINISTRA, ON);
    delay(tempo);
    digitalWrite(DESTRA, OFF);
    digitalWrite(SINISTRA, OFF);
    // apply = false;
    break;

  // Ferma rotazione
  case 'F':
    dir = 0;
    digitalWrite(DESTRA, OFF);
    digitalWrite(SINISTRA, OFF);
    break;

  // Relais velocità veloce
  case 'V':
    digitalWrite(VELOCITA, OFF);
    break;

  // Relais velocità lenta
  case 'v':
    digitalWrite(VELOCITA, ON);
    break;

  // Apri cupola
  case 'C':
    digitalWrite(APRI_CUPOLA, ON);
    delay(500);
    digitalWrite(APRI_CUPOLA, OFF);
    break;

  // Chiudi cupola
  case 'c':
    digitalWrite(CHIUDI_CUPOLA, ON);
    delay(500);
    digitalWrite(CHIUDI_CUPOLA, OFF);
    break;

  // Impulso relais montatura
  case 'A':
    digitalWrite(RELAIS_MONTATURA, ON);
    delay(2000);
    digitalWrite(RELAIS_MONTATURA, OFF);
    break;

  // Accensione relais GPS
  case 'G':
    digitalWrite(RELAIS_GPS, ON);
    break;

  // Spegnimento relais GPS
  case 'g':
    digitalWrite(RELAIS_GPS, OFF);
    break;

  // Comunica il numero di piedi
  case 'P':
    Serial.print(piedi);
    break;

  // Comunica lo stato del portellone
  case 'B':
  {
    if (digitalRead(CUPOLA_APERTA) == ON)
    {
      if (digitalRead(CUPOLA_CHIUSA) == ON)
      {
        Serial.print("M");
      }
      else if (digitalRead(CUPOLA_CHIUSA) == OFF)
      {
        Serial.print("C");
      }
    }
    else if (digitalRead(CUPOLA_APERTA) == OFF)
    {
      if (digitalRead(CUPOLA_CHIUSA) == ON)
      {
        Serial.print("A");
      }
      else if (digitalRead(CUPOLA_CHIUSA) == OFF)
      {
        Serial.print("O");
      }
    }
    break;
  }

  // Parcheggia la cupola
  case 'Q':
  {
    digitalWrite(VELOCITA, OFF);
    if (piedi < POS_PARK)
    {
      digitalWrite(DESTRA, ON);
      digitalWrite(SINISTRA, OFF);
    }
    else if (piedi > POS_PARK)
    {
      digitalWrite(DESTRA, OFF);
      digitalWrite(SINISTRA, ON);
    }
    else if (piedi == POS_PARK)
    {
      digitalWrite(DESTRA, OFF);
      digitalWrite(SINISTRA, OFF);
    }
    while (digitalRead(HOMING) == OFF)
    {
    };
    digitalWrite(VELOCITA, ON);
    delay(1000);
    if (piedi < POS_PARK)
    {
      digitalWrite(DESTRA, OFF);
      digitalWrite(SINISTRA, ON);
    }
    else if (piedi > POS_PARK)
    {
      digitalWrite(DESTRA, ON);
      digitalWrite(SINISTRA, OFF);
    }
    else if (piedi == POS_PARK)
    {
      digitalWrite(DESTRA, OFF);
      digitalWrite(SINISTRA, OFF);
    }
    while (digitalRead(HOMING) == OFF)
    {
    };
    digitalWrite(VELOCITA, OFF);
    digitalWrite(DESTRA, OFF);
    digitalWrite(SINISTRA, OFF);
    digitalWrite(CHIUDI_CUPOLA, ON);
    delay(500);
    digitalWrite(CHIUDI_CUPOLA, OFF);
    break;
  }

  // Sensore di pioggia escluso
  case 'R':
    digitalWrite(ESCLUSIONE_PIOGGIA, ON);
    break;

  // Sensore di pioggia considerato
  case 'r':
    digitalWrite(ESCLUSIONE_PIOGGIA, OFF);
    break;

  // Stato selettore pioggia
  case 'I':
    Serial.println(digitalRead(STATO_SELETTORE_PIOGGIA));
    break;

  // Emergenza pioggia
  case 'E':
  {
    if (digitalRead(SENSORE_PIOGGIA) == ON)
    {
      Serial.println("P");
    }
    else if (digitalRead(SENSORE_PIOGGIA) == OFF)
    {
      Serial.println("NP");
    }
    break;
  }

  // Ritorna lo stato del pannello
  case 'X':
    Serial.println(!digitalRead(39));
    break;

  // Accende o spegne il pannello
  case 'x':
  {
    if (digitalRead(STATO_PANNELLO) == ON)
    {
      digitalWrite(PANNELLO_OFF, ON);
      delay(1000);
      digitalWrite(PANNELLO_OFF, OFF);
    }
    else if (digitalRead(STATO_PANNELLO) == OFF)
    {
      digitalWrite(PANNELLO_ON, ON);
      delay(1000);
      digitalWrite(PANNELLO_ON, OFF);
    }
    break;
  }

  // Blocca ogni movimento della cupola
  case 'K':
  {
    // digitalWrite(HOMING, OFF);
    digitalWrite(DESTRA, OFF);
    digitalWrite(SINISTRA, OFF);
    digitalWrite(VELOCITA, OFF);
    // digitalWrite(APRI_CUPOLA, OFF);
    // digitalWrite(CHIUDI_CUPOLA, OFF);
    // digitalWrite(RELAIS_MONTATURA, OFF);
    // digitalWrite(RELAIS_GPS, OFF);
    // digitalWrite(IMPULSI, OFF);
    // digitalWrite(CUPOLA_APERTA, OFF);
    // digitalWrite(CUPOLA_CHIUSA, OFF);
    // digitalWrite(EST, OFF);
    // digitalWrite(OVEST, OFF);
    // digitalWrite(SENSORE_PIOGGIA, OFF);
    // digitalWrite(PANNELLO, OFF);
    // digitalWrite(ESCLUSIONE_PIOGGIA, OFF);
    // digitalWrite(STATO_SELETTORE_PIOGGIA, OFF);
    // digitalWrite(STATO_PANNELLO, OFF);
    while (true)
    {
      if (Serial.read() == 'K')
      {
        break;
      }
    }
    break;
  }
  }

  if (digitalRead(IMPULSI) == HIGH)
  {
    currentState = 1;
  }
  else
  {
    currentState = 0;
  }
  if (currentState != previousState)
  {
    if (currentState == 1)
    {
      piedi = piedi + dir;
    }
  }

  previousState = currentState;

  if (digitalRead(HOMING) == ON)
    piedi = POS_PARK;
  else if (digitalRead(EST) == ON)
    piedi = POS_EST;
  else if (digitalRead(OVEST) == ON)
    piedi = POS_OVEST;
  else if (digitalRead(NORD) == ON)
    piedi = POS_NORD;
}
