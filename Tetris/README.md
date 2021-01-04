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
Bezerra foram feitas, como a criação de uma nova `Thread` para um *timer* que
decide a velocidade de queda das peças e seus respetivos métodos, assim como
algumas contribuições de Daniel Fernandes.

#### `DoubleBuffer2D`, `Scene`, `TitleScreen` e `Tutorial`

Classes inteiramente feitas por Marco Domingos.

#### `IDisplay`

Interface inteiramente feita por Marco Domingos.

#### `Pixel`

*Struct* inteiramente feita por Marco Domingos.

### Pedro Bezerra

* Classes `Score`, `Board`
* *Struct* `Coord`
* *Enum* `Dir`
* Responsável por parte de **Autoria**, **Referências**


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