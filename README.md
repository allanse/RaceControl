# RaceControl

Projetos para fins de estudo em :

- DotNet Core;
- ORM - Entity FrameWork Core;
- Autofac;
- Automapper;
- DDD;

Objetivo do projeto:

Criar uma API simples para controle de competições em corridas que tenha:

- Separação em pelo menos 3 camadas (Ex.: API, negocios e dados;
- CRUD completo para controle dos competidores;
- CRUD completo para controle das pistas;
- Cadastro (inclusão e alteração) do histórico de corridas;
- Listagem de quais pistas já foram utilizadas;
- Listagem dos competidores com o tempo médio gasto
nas corridas;
- Listagem dos competidores que não fizeram nenhuma
corrida;
Validações:
  Validar se a temperatura média do corpo se encontra entre 36 e 38;
  Validar se peso e altura são valores positivos;
  Validar se sexo é M, F ou O;
  Validar se data da corrida não está no futuro;

TODO List:

- [ ] Validar se sexo é M, F ou O;
- [ ] Listagem dos competidores com o tempo médio gasto
nas corridas;
- [x] Listagem dos competidores que não fizeram nenhuma
corrida;
- [ ] Criar teste unitários;
- [ ] Criar sistema de notificações para tratar erros;
- [ ] Utilizar docker;


