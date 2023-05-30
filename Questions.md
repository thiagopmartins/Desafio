## Estrutura

Para completar o desafio, gerei uma estrutura (api) simples, onde teremos 3 camadas, sendo elas:
* Presentation: camada de entrada da api, principal caracteristica é conter os controllers.
* Application: camanda onde possui o código com a resolução dos problemas, toda lógica fica armazenada nos handlers
* Tests: camada onde possui os testes de cada handler, foi gerado apenas os testes de handlers.

## Questões

##### 1 - Como você implementou a função que retorna a representação por extenso do número no desafio 1? Quais foram os principais desafios encontrados?
R: Para resolver o primeiro desafio, gerei um endpoint GET */api/GetFullNameNumber/* que recebe por parametro um inteiro e retorna seu nome por extenso.
O principal desafio foi tratar as dezenas, tendo em vista que são valores unicos, a partir delas, os valores se repetem e ficando assim mais facil de desenvolver.

##### 2 - Como você lidou com a performance na implementação do desafio 2, considerando que o array pode ter até 1 milhão de números?
R: Para resolver esse desafio, gerei um endpoint POST (por ser um array possivelmente grande) */api/ArraySum* que recebe em seu body um array de inteiros e retorna a soma de seus valores.
Para a implementação desta questão, eu utilizei da função Sum() que vem junto com a biblioteca Linq do próprio C#, que já possui uma performance boa

### 3 - Como você lidou com os possíveis erros de entrada na implementação do desafio 3, como uma divisão por zero ou uma expressão inválida?
R: Para resolver esse desafio, gerei um endpoint POST */api/CalculateMathFunction* que recebe em seu body uma expressão matematica e devolve o seu resultado.
Algumas validações foram necessárias, primeiramente foi verificar se a expressão é valida, não deixei que fosse iniciada ou finalizada por uma operação (+, -, *, /). Uma outra validação foi a do denominador, que não pode ser 0, para essa validação peguei o index que possiu o sinal / e verifiquei o valor do próximo index, que por sua vez não pode ser 0.
A lógica utilizada para solucionar o desafio foi a seguinte, primeiramente eu resolvo todas as expressões que possuem prioridade (* ou /), para somente depois resolver o restante

### 4 - Como você implementou a função que remove objetos repetidos na implementação do desafio 4? Quais foram os principais desafios encontrados?
R: Para resolver esse desafio, gerei um endpoint POST */api/DistinctElements* que recebe em seu body um array de string e retorna um array de valores unicos.
Para a implementação desta questão, eu utilizei da função Distinc(), que faz parte da biblioteca Linq do próprio C#