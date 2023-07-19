# Jogo da Velha :hash:
Jogo TicTac Toe, desenvolvido em linguagem C#, e executado através do Windows Console.

💻 Tecnologia utilizada
---------
![image](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)

## Requisitos da atividade
- Jogo ocorre em um tabuleiro de 3 por 3;
- Jogo será jogado por duas pessoas de forma alternada;
- Jogador 1 será sempre o primeiro a jogar;
- Jogador 1 será representado pelo nome de sua escolha e pela letra 'X';
- Jogador 2 será representado pelo nome de sua escolha e pela letra 'O';
- Jogador que formar primeiro uma reta na diagonal, vertical ou horizontal do tabuleiro será o ganhador;
- O jogo poderá ter 3 resultados: vitória do jogador 1, vitória do jogador 2 ou empate;

## Ordem de execução
- <b>`Passo 1:`</b> Será solicitado para o jogador 1 o seu nome, em seguida será solicitado o nome para o jogador 2;
- <b>`Passo 2:`</b> Solicita um número dentro do intervalo de 1 a 9 para o jogador da vez, caso a entrada seja diferente do esperado, o jogo irá pedir um novo valor;
- <b>`Passo 3:`</b> Verifica se a opção escolhida já foi selecionada anteriormente, caso já tenha sido escolhida, será informado ao usuário que a posição está preenchida e será solicitada um novo valor valido, caso contrário mostra no tabuleiro a opção escolhida de acordo com o letra do jogador;
- <b>`Passo 4:`</b> Após a quinta jogada o sistema irá checar um caso de vitória através de uma lista de possibilidades, caso se confirme um vencedor o sistema irá mostrar uma mensagem informando e o sistema será encerrado, caso contrário, segue o jogo;
- <b>`Passo 5:`</b> O jogo segue de forma dinâmica, repetindo os passos 1, 2, 3 e 4 a cada rodada, até que seja atendido os requisitos de vitória ou empate.
- <b>`Passo 6:`</b> Caso não se confirme um ganhador, o sistema irá retornar uma mensagem em informando o empate, e o jogo será encerrado.