# Jogo Gourmet

O Jogo Gourmet é um projeto desenvolvido como parte de um desafio técnico para uma vaga na Objective. O objetivo do jogo é permitir que a máquina adivinhe o prato que o usuário está pensando. Quando a máquina não consegue adivinhar corretamente, ela solicita informações ao usuário para melhorar suas tentativas futuras.

## Sobre o Projeto

Este projeto foi implementado utilizando Windows Forms com .NET 8.0 e Visual Studio 2022. Foram aplicados conceitos de CQRS (Command Query Responsibility Segregation) e injeção de dependência para garantir uma arquitetura robusta e escalável. Além disso, foram desenvolvidos testes unitários para assegurar a qualidade do código.

## Como Executar

Na release, estão disponíveis dois arquivos compactos com executáveis:
1. **Executável com Runtime Embutido:** Inclui o runtime .NET, permitindo a execução sem necessidade de instalação adicional. (arquivo maior)
2. **Executável Dependente do Runtime .NET:** Requer que o runtime .NET esteja instalado no sistema. (arquivo menor)

Escolha o arquivo mais adequado às suas necessidades, extraia o conteúdo e execute o arquivo `JogoGourmet.exe`.

## Requisitos do Sistema

- **Windows:** Sistema operacional compatível com Windows Forms.
- **.NET Runtime (para o executável menor):** Certifique-se de ter o runtime .NET 8.0 instalado no seu sistema.

## Estrutura do Projeto

O projeto segue a arquitetura CQRS, separando as operações de comando (escrita) das operações de consulta (leitura). A injeção de dependência é utilizada para gerenciar as dependências entre os componentes do sistema, proporcionando maior modularidade e facilidade de manutenção.

## Desenvolvimento

O desenvolvimento do Jogo Gourmet foi realizado por Adrian Procopiou, utilizando as melhores práticas de desenvolvimento de software para criar uma aplicação divertida e educativa. A implementação cuidadosa visa demonstrar habilidades técnicas em C#, .NET, e arquitetura de software.

## Contato

Para qualquer dúvida ou sugestão, sinta-se à vontade para entrar em contato.

---

Obrigado por avaliar o Jogo Gourmet! Espero que gostem da solução e fiquem à vontade para fornecer feedback.

---

**Adrian Procopiou**
