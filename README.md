
  

<h1  align="center">Oralytics</h1>

![.NET](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)

![GitHub](https://img.shields.io/badge/github-%23121011.svg?style=for-the-badge&logo=github&logoColor=white)

![Oracle](https://img.shields.io/badge/Oracle-F80000?style=for-the-badge&logo=oracle&logoColor=white)

## Integrantes do Grupo

Kayque Ferreira dos Santos - Desenvolvedor Backend

André Alves da Silva - Desenvolvedor Backend

Gabriel de Souza Grego - Desenvolvedor Frontend (não atuou nesse código)

# Oralytics - Dental Health Monitoring Platform

  

## 🦷 Descrição

  

O **Oralytics** é uma plataforma voltada para o monitoramento da saúde dentária dos usuários. Utilizamos inteligência artificial para ajudar os usuários a manterem uma rotina saudável de higiene bucal, identificando problemas dentários a partir de informações de monitoramento e oferecendo orientações personalizadas baseadas no perfil de cada usuário.

  

---

  

## 🎯 Objetivo do Projeto

  

O projeto **Oralytics** tem como objetivo principal resolver problemas relacionados ao monitoramento inadequado da saúde bucal e fornecer orientações personalizadas para usuários e profissionais da área odontológica. A plataforma visa:

  

- Ajudar pacientes a monitorar sua saúde bucal com mais eficiência.

- Proporcionar a dentistas e clínicas odontológicas uma ferramenta para acompanhar o progresso dos pacientes.

- Identificar precocemente possíveis problemas dentários com a ajuda de IA e dados de monitoramento.

  

---

  

## 📋 Escopo

  

A aplicação **Oralytics** irá:

  

1. Coletar dados de saúde bucal dos usuários, como frequência de escovação, histórico de problemas relatados e outros parâmetros relacionados.

2. Utilizar inteligência artificial para identificar padrões que possam indicar problemas dentários.

3. Fornecer relatórios detalhados com base nos dados coletados, oferecendo recomendações personalizadas.

4. Permitir que dentistas e clínicas acompanhem o progresso dos pacientes através de dashboards personalizados.

5. Garantir o armazenamento seguro dos dados dos usuários.

  

**Funcionalidades principais**:

- Cadastro de usuários (pacientes e dentistas).

- Coleta de dados de higiene bucal.

- Geração de relatórios e recomendações personalizadas.

- Acompanhamento de pacientes por parte dos profissionais de saúde.

- Interface de monitoramento e histórico de saúde bucal.

  

---

  

## ✅ Requisitos Funcionais

  

1.  **Autenticação de Usuários**:

- O sistema deve permitir que pacientes e dentistas se registrem e façam login.

2.  **Coleta de Dados**:

- O sistema deve coletar dados de higiene bucal, como frequência de escovação e informações de check-ups odontológicos.

  

3.  **Geração de Relatórios**:

- A aplicação deve gerar relatórios personalizados de acordo com o perfil do usuário.

  

4.  **Acompanhamento de Pacientes**:

- Dentistas devem ter a capacidade de acessar o histórico de seus pacientes e visualizar o progresso deles.

  

5.  **Notificações e Recomendações**:

- O sistema deve notificar os usuários sobre possíveis problemas dentários detectados pela IA e sugerir recomendações de cuidados.

  

---

  

## 🚧 Requisitos Não Funcionais

  

1.  **Segurança**:

- Os dados dos usuários devem ser criptografados para garantir a privacidade e a segurança das informações.

  

2.  **Escalabilidade**:

- O sistema deve ser capaz de lidar com um grande número de usuários simultâneos, garantindo alta disponibilidade e desempenho.

  

3.  **Usabilidade**:

- A interface da aplicação deve ser intuitiva e fácil de usar, tanto para pacientes quanto para dentistas.

  

4.  **Desempenho**:

- A aplicação deve responder rapidamente às interações do usuário e gerar relatórios em tempo hábil.

  

  
 ---
 ##  🆚 Monolito vs Microserviços
 Uma arquitetura monolítica, consiste em manter todos os componentes do software dentro de uma única aplicação, enquanto o microserviços tem a idéia de separar diferentes componentes em aplicações invididuais, mas mantendo uma comunicação (API por exemplo). 
 
 ---

## 📐 Arquitetura Escolhida
Arquitetura escolhida é **monolítica**, pois a aplicação não irá ser muito grande, não havendo necessidade de dividi-la o pequenas partes como ocorre em microserviços. Optandor por uma arquitetura **monolítica**, irá simplificar o processo de desenvolvimento e manutenção, dado que todos os componentes estarão juntos em uma unica aplicação. Reduzindo complexidade, facilitando o gerencimaento de implantação em um ambiente _Cloud_ por exemplo, além de ser mais aderente a projetos de menor escala, como é o caso dessa solução. 
  
 Além disso, uma arquitetura de microserviços exigiria um gerenciamento de cada aplicação, acrescentando uma complexidade a mais para gerenciar e manter a comunicação entre os serviços independentes.  
 
 ---
 ## Design Pattern de criação de objetos
 Foi utilizado o **Mapper Pattern** para criar um objeto DTO através de um objeto de domínio.
 Trecho de uso do Design Pattern no código do projeto:
 ```
  public class DentalAnalysisMapper
 {
     public static DentalAnalysisResponse ToDTO(DentalAnalysis dentalAnalysis)
     {

         return new DentalAnalysisResponse(
             Id: dentalAnalysis.Id,
             User: dentalAnalysis.User, 
             AnalysisDate: dentalAnalysis.AnalysisDate,
             ProbabilityProblem: dentalAnalysis.ProbabilityProblem,
             MonitoringDataIds: dentalAnalysis.MonitoringDataList?.Select(md => md.Id).ToList() ?? new List<int>()
         );
     }

     public static List<DentalAnalysisResponse> ToDTO(IEnumerable<DentalAnalysis> dentalAnalysis)
     {

         return dentalAnalysis.Select(da =>  ToDTO(da)).ToList();
     }
 }
 ``` 

## 💡 Tecnologias Utilizadas

  

-  **Backend**: C# com ASP.NET

-  **Frontend**: React Native

-  **Banco de Dados**: Oracle

-  **Inteligência Artificial**: Roboflow

-  **Hospedagem**: Azure

  

---

## Diagramas

### Diagrama tabela banco de dados

![Alt text](https://i.ibb.co/3TGp8PB/Untitled.png)
## Rotas para ter acesso a view
```markdown
- User: https://localhost:${PORT}/User
- MonitoringData: https://localhost:${PORT}/MonitoringData
- DentalHistory: https://localhost:${PORT}/DentalHistory
```
## Video explicação projeto

[LINK PARA O VIDEO](https://www.youtube.com/watch?v=QAhvlBJQTMM)
