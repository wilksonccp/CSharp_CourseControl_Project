# CSharp_CourseControl_Project

## Visão Geral
O **CSharp_CourseControl_Project** é uma aplicação simples para gerenciamento de cursos e estudantes, desenvolvida em C#. O projeto permite a criação, matrícula, exclusão e listagem de estudantes e cursos, utilizando um menu interativo em linha de comando. 

## Funcionalidades
- **Registro de Estudantes**: Permite a inserção de novos estudantes com validação de ID único.
- **Registro de Cursos**: Permite a inserção de novos cursos, incluindo código do curso, nome, descrição com limite de caracteres e preço.
- **Matrícula de Estudantes** (em desenvolvimento): Permite matricular estudantes em cursos existentes.
- **Exclusão de Estudantes e Cursos** (em desenvolvimento): Permite remover estudantes ou cursos da base de dados.
- **Geração de Relatórios** (em desenvolvimento): Gera relatórios listando estudantes, cursos e matrículas.

## Estrutura do Projeto
- **Program.cs**: Arquivo principal onde as listas de estudantes e cursos são gerenciadas.
- **UserInteractions.cs**: Classe responsável por gerenciar a navegação nos menus e a interação com o usuário.
- **ValidationHelper.cs**: Classe auxiliar que contém métodos para validações genéricas, como verificação de IDs únicos e limite de caracteres.
- **Student.cs**: Classe que define o modelo de Estudante, incluindo métodos para registro e gerenciamento de estudantes.
- **Course.cs**: Classe que define o modelo de Curso, incluindo métodos para registro e gerenciamento de cursos.

## Tecnologias Utilizadas
- **C# 8.0**: Linguagem de programação principal.
- **.NET 8.0**: Framework utilizado para o desenvolvimento.
- **Visual Studio Code**: Ambiente de desenvolvimento.

## Como Executar
1. **Clone o Repositório**:
   ```bash
   git clone https://github.com/seu-usuario/CSharp_CourseControl_Project.git
   ```
2. **Compile e Execute**:
   - Abra o projeto no Visual Studio Code.
   - Compile o projeto:
     ```bash
     dotnet build
     ```
   - Execute o projeto:
     ```bash
     dotnet run
     ```
3. **Navegue pelos Menus**:
   - Siga as instruções no terminal para registrar estudantes, cursos e navegar pelo sistema.

## Testes e Verificação
- **Testes de Navegação**: Verificados todos os menus e submenus, garantindo que redirecionem corretamente.
- **Validações**: Implementadas e testadas para garantir a integridade dos dados inseridos (IDs únicos, limite de caracteres, etc.).
- **Testes de Registro**: Testes realizados para garantir que estudantes e cursos são registrados corretamente nas listas.

## Futuras Melhorias
- **Implementação da Matrícula de Estudantes em Cursos**.
- **Função para Excluir Estudantes e Cursos**.
- **Geração de Relatórios Detalhados**.
- **Integração com Banco de Dados para Persistência de Dados**.

## Contribuições
Contribuições são bem-vindas! Sinta-se à vontade para abrir issues e enviar pull requests.

## Licença
Este projeto é licenciado sob os termos da licença MIT.
