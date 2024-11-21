## Princess Pasta
### Sobre
Oiê, esse repo é do jogo "Princess Pasta", onde uma princesa cadeirante busca por sua liberdade aliada de seu companheiro, o Felipe (bobo da corte).

### Participantes
Carlos Isidro
Juliana Bertolazi Simon
Lucas Emanoel
Nicolas Vera


### Sistema de Vida da princesa

A vida fica salva nos registros do windows por meio do PlayerPrefs, 
a vida deve ser resetada toda vez que o jogo inicia (menu principal - play) e quando o jogo é reiniciado (GameOver).

Para alterar a vida da princesa, utilize:
# PlayerPrefs.SetInt("Vida", vidaAtual);

O primeiro termo é o nome no registro e o segundo é o valor da vida, exemplo de script abaixo:

                vidaAtual--; // Variavel que guarda o valor da vida atual da princesa
                PlayerPrefs.SetInt("Vida", vidaAtual); // Set da vida da princesa.

O script do objeto Vida, no Update, irá realizar a atualizaçao do novo valor da vida para a exibição visual (os corações na tela).

Se precisarem de ajuda pra fazer a lógica de vida, só me chamar, também tem o exemplo do meu código da Princesa.

