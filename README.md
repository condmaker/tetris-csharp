# Projeto 2 da Disciplina de Linguagens de Programação 2

## *Tetris*

* Marco Domingos, a21901309  
* Daniel Fernandes, a21902752  
* Pedro Bezerra, a21900974  

## Autoria

Nesta secção será indicado exatamente o que cada aluno fez no projeto. Para
além do que será mencionado, cada aluno também trabalhou em pequenas partes do
programa dos outros membros do grupo (arranjar *bugs*, pequenas
funcionalidades).

As secções serão separadas por alunos e o que cada um deles fez. Não haverão
classes/interfaces/enumerados/etc... repetidos entre secções, e as 'pequenas
contribuições' já referidas estarão nas secções onde tal contribuição foi 
feita.

[**Link para o repositório *Github* do projeto**][github]

### Marco Domingos

* Classes `Client`, `DoubleBuffer2D`, `Scene`, `TitleScreen`, `Tutorial`
* Interface `IDisplay`
* *Struct* `Pixel`
* Responsável por parte de **Autoria**, **Referências**, e toda a 
**Arquitetura da Solução**
* Criação da documentação em *Doxygen*

#### `Client`

Classe feita parcialmente por Marco Domingos. Várias contribuições de Pedro
Bezerra foram feitas, como a criação das *Threads* (para input e *game speed*),
assim como seus métodos, junto com algumas contribuições de Daniel Fernandes.

#### `DoubleBuffer2D`, `Scene`, `TitleScreen` e `Tutorial`

Classes inteiramente feitas por Marco Domingos.

#### `IDisplay`

Interface inteiramente feita por Marco Domingos.

#### `Pixel`

*Struct* inteiramente feita por Marco Domingos.

### Pedro Bezerra

* Classes `Board`, `Score`
* *Struct* `Coord`
* *Enum* `Dir`
* Responsável por parte de **Autoria**, **Referências**
* Maior parte da documentação do projeto
* Corrigiu maior parte das *Warnings* no projeto.

#### `Board`

Classe feita parcialmente por Pedro Bezerra, com várias contribuições por
Daniel Fernandes e algumas por Marco Domingos, como por exemplo o override do
método `Update()`, `ChangePiecePos()`, `IsRotationPossible()`. `ClearBoard()`,
`InitializeBoard()` e `InitializePiece()` foram feitos em conjunção com
Marco Domingos e Pedro Bezerra.

#### `Score`

Classe inteiramente feita por Pedro Bezerra.

#### `Coord`

*Struct* inteiramente feita por Pedro Bezerra.

#### `Dir`

*Enum* inteiramente feito por Pedro Bezerra.

### Daniel Fernandes

* Classes `GameObject`, `Tetromino`, `JPiece`, `LPiece`, `LinePiece`,
`SquarePiece`, `SPiece`, `TPiece`, `ZPiece`
* UML

Todas as classes referidas nesta secção foram inteiramente feitas por Daniel
Fernandes, com exceção de documentação XML, que foi feita em sua maioria 
por Pedro Bezerra.

## Arquitetura da Solução

O programa implementou vários *design patterns* de forma a organizar e estrutrar
bem o código. Os mais importantes destes *patterns* foram o *Game Loop Pattern*,
que é implementado no método `Client` (com uma implementação bem básica, sem 
um passo fixo), e o *Update Method*, que é feito de uma forma diferente do
comum devido a existência de **cenas** no programa-- é feito o *update* da cena
específica que está a 'rodar', e depois um update que verifica se esta cena
irá mudar para outra ou não.  
Dentro do *update* da cena específica que é feito o *update* de todos os
*GameObjects* dentro dela.

Outros *patterns* presentes são o *Strategy Pattern* com *IDisplay*, e o
*Template Method Pattern* com a classe abstrata `Tetromino` e suas
concretizações.

O *Strategy Pattern* foi utilizado com *IDisplay* de forma a ser possível
alterar os métodos de renderização sem afetar o resto do programa, e o
*Template Method Pattern* foi utilizado para fazer com que cada `Tetromino`
concreto tenha aspetos em comum de forma a serem todos utilizados na `Board`.

### Descrição da Solução

![flux]

Como já dito anteriormente, o jogo utiliza o *Game Loop* e o *Update Method*
como *design patterns* para fazer com que o jogo tenha atualizações por *frames*
. De forma a conseguir separar 'lugares' diferentes, foram implementadas
**cenas**, `GameObject`s que representam um 'espaço' no programa.

Todas as cenas utilizam o input do jogador, apanhado na **Thread A**, para
verificação.

#### Cena `TitleScreen`

Simplesmente contem um `bool` que indica para qual cena esta a apontar,
`Board` ou `Tutorial`. Concede acesso a estas duas cenas, sendo esta a sua única
função.

#### Cena `Tutorial`

Explica ao jogador como controlar o jogo. Qualquer *input* nesta cena irá fazer
com que ela volte a anterior.

#### Cena `Board`

É a cena que controla o jogo e que faz os updates de todas as peças, do
'tabuleiro', e do **score**. O *input* '**Enter**' retorna o jogador a cena
anterior.

### UML e Descrição das Classes

Esta secção irá demontrar o diagrama UML do projeto e comentar sobre a
organização do mesmo. Algumas classes apresentadas no diagrama-- as mais símples ou que não têm muitas ligações por exemplo, não serão especificadas.

![uml]

#### Classe `Program`

Instancia `Client` em main e inicia seu loop, além de alterar o 
`OutputEncoding` para Unicode. Visto que ela apenas instancia e utiliza um
método de `Client` em `Main()`, a relação é de dependência.

#### Classe `Client`

Contém um instância do *enum* `Dir`, que será atribuido de acordo com os inputs
do jogador. Também contém uma instância de `Scene`, `currentScene`, que define
a cena atual a correr naquele momento (ainda também tem 3 instâncias de 
`scene`s que são instanciadas em `GameLoop()`). Por fim, no método `GameLoop()`
é definido uma instância de `IDisplay` de forma a fazer a renderização.

Visto que ambos estes são simples variáveis de instância em `Client`, os dois
têm a relação de associação com a classe. Como `IDisplay` é instanciado como
uma variável de método, tem uma relação de dependência.

#### Classe `Scene`

Existem 3 classes que herdam de `Scene`: `TitleScreen`, `Tutorial`, e `Board`.
Esta classe abstrata herda de `GameObject` para utilizar o método `Update()` e
ser atualizado toda frame. Também define o método `UpdateMethod()`, que devolve
uma `Scene`, de forma a trocar a `Scene` atual para outra em `Client`.

#### Classe `ConsoleDisplay`

Implementa a interface `IDisplay` e é responsável pelo *rendering* do jogo.
Tem uma variável de instância de `DoubleBuffer2D` (tendo assim uma relação de
associação com a mesma), que escreve em *buffers* e os imprime
no ecrã da consola.

#### *Struct* `Pixel`

Define o que é um '*pixel*' para o jogo, e consiste de dois campos-- um `char`
e um `ConsoleColor`. Isto permite que cada '*pixel*' tenha uma cor diferente e 
um caractére ao mesmo tempo. É utilizado em matrizes em `Board` e 
`DoubleBuffer2D`, fazendo com que essas classes tenham uma relação de agregação
com `Pixel`.

#### Classe `Tetromino`



## Referências

Algumas implementações do jogo de Tetris encontradas online foram usadas como 
referência em algumas partes do código. Essas implementações podem ser 
encontradas nos seguintes links:

* [Tetris tutorial in C++ platform independent focused in game logic for beginners][linkTetris1]  
* [Writing Tetris in python][linkTetris2]  
  
A classe `Tetromino` implementa a interface `IEnumerable`, com base no código
encontrado [aqui][linkIEnum].

A classe `DoubleBuffer2D` também foi fortemente baseada na classe de mesmo
nome criada por Nuno Fachada neste [link][linkBuffer].


[linkIEnum]: https://stackoverflow.com/questions/13135443/how-to-make-the-class-as-an-ienumerable-in-c
[linkTetris1]: https://javilop.com/gamedev/tetris-tutorial-in-c-platform-independent-focused-in-game-logic-for-beginners/
[linkTetris2]: https://levelup.gitconnected.com/writing-tetris-in-python-2a16bddb5318
[linkBuffer]: https://github.com/fakenmc/CoreGameEngine/blob/master/CoreGameEngine/ConsoleRenderer.cs
[github]: https://github.com/condmaker/tetris-csharp
[flux]: Diagrams/fluxo.png
[uml]: Diagrams/uml.png