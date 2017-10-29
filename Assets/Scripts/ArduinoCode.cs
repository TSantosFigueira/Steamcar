//Definição dos pin's responsáveis pelos respectivos Push Buttons
const int botaoEsquerdo = 3;
const int botaoDireito = 4;

void setup()
{
    Serial.begin(9600);
    pinMode(botaoEsquerdo, INPUT);
    digitalWrite(botaoEsquerdo, HIGH);
    pinMode(botaoDireito, INPUT);
    digitalWrite(botaoDireito, HIGH);
}

//Método de Leitura Constante do Estado dos Push Butons
void loop()
{
    if (digitalRead(botaoEsquerdo) == LOW)
    {
        Serial.write(1);
        Serial.flush();
        delay(20);
    }
    if (digitalRead(botaoDireito) == LOW)
    {
        Serial.write(2);
        Serial.flush();
        delay(20);
    }
}
