# Kanban API

A task for Kanban Board API.

### Users

List: GET `GetUsers`

Create: POST `CreateUser`

Single: GET `GetUser`

Update: PATCH `UpdateUser`

Delete: DELETE `DeleteUser`

### Boards

List: GET `GetBoardsInUser`

Create: POST `CreateBoard`

Single: GET `GetBoard`

Update: PATCH `UpdateBoardName`

Delete: DELETE `DeleteBoard`

### Status

List: GET `GetStatusesInBoard`

Create: POST `CreateStatus`

Single: GET `GetStatus`

Update: PATCH `UpdateStatus`

Delete: DELETE `DeleteStatus`

### Tasks

List: GET `GetTasksInStatus`

Create: POST `CreateTask`

Single: GET `GetTask`

Update: PATCH `UpdateTask`

Delete: DELETE `DeleteTask`

Add: POST `AddUserToTask`

Add: POST `AddTagToTask`

Update: PATCH `UpdateTaskOrder`

### Comments

Create: POST `CreateComment`

Single: GET `GetComment`

Delete: DELETE `DeleteComment`

