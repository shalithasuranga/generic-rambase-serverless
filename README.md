# Generic Rambase Serverless Function

Steps to create a function

- clone repo 
```bash
get clone https://github.com/shalithasuranga/generic-rambase-serverless.git
```

- Write or paste converted cos to `serverless/ServerlessFunction.cs`
- Deploy function

```bash
cd generic-rambase-serverless
python faas.py
```
Just enter the function name and it will give back the url. If function is already deployed it will perform rolling update.


### Prerequisites 

- Docker, User should logged in to dockerhub, Faas CLI, Running Open Faas Gateway
