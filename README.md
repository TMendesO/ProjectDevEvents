# Projeto Rest API com ASP .NET Core

Este é um projeto de exemplo de uma API REST feito com ASP .NET Core para gerenciar eventos de desenvolvimento.

## Controller: `DevEventsController`

O controlador `DevEventsController` gerencia as operações relacionadas aos eventos de desenvolvimento.

### Endpoints:

1. **GET `/api/dev-events`**
   - Retorna todos os eventos de desenvolvimento.
  
2. **GET `/api/dev-events/{id}`**
   - Retorna um evento específico com base no ID fornecido.

3. **POST `/api/dev-events`**
   - Cria um novo evento de desenvolvimento.
   - Exemplo de corpo da solicitação:
     ```json
     {
       "title": "Exemplo de Evento",
       "description": "Uma descrição interessante",
       "startDate": "2023-06-01T10:00:00.000Z",
       "endDate": "2023-06-01T18:00:00.000Z"
     }
     ```

4. **PUT `/api/dev-events/{id}`**
   - Atualiza um evento existente com base no ID fornecido.
   - Exemplo de corpo da solicitação:
     ```json
     {
       "title": "Novo Título",
       "description": "Nova descrição",
       "startDate": "2023-06-01T12:00:00.000Z",
       "endDate": "2023-06-01T20:00:00.000Z"
     }
     ```

5. **DELETE `/api/dev-events/{id}`**
   - Exclui um evento existente com base no ID fornecido.

6. **POST `/api/dev-events/{id}/speakers`**
   - Adiciona um palestrante a um evento existente com base no ID fornecido.
   - Exemplo de corpo da solicitação:
     ```json
     {
       "name": "John Doe",
       "talkTitle": "Amazing Talk",
       "talkDescription": "An inspiring talk about technology",
       "linkedInProfile": "https://www.linkedin.com/in/johndoe"
     }
     ```

## Entidades: `DevEvent` e `DevEventSpeaker`

### `DevEvent`

- `Id`: Identificador único do evento.
- `Title`: Título do evento.
- `Description`: Descrição do evento.
- `StartDate`: Data de início do evento.
- `EndDate`: Data de término do evento.
- `Speakers`: Lista de palestrantes associados ao evento.
- `IsDeleted`: Indica se o evento foi excluído.

### `DevEventSpeaker`

- `Id`: Identificador único do palestrante.
- `Name`: Nome do palestrante.
- `TalkTitle`: Título da apresentação do palestrante.
- `TalkDescription`: Descrição da apresentação do palestrante.
- `LinkedInProfile`: Perfil do LinkedIn do palestrante.

## Contexto de Persistência: `DevEventsDBContext`

O contexto de persistência `DevEventsDBContext` emula um banco de dados em memória.

## Injeção de Dependência:

```csharp
builder.Services.AddSingleton<DevEventsDBContext>();
```

Isso registra o contexto de banco de dados como um serviço singleton para emular um banco de dados em memória.

