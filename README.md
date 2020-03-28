# OmniStack 11 com Dotnet Core, Angular e futuramente Flutter.

Optei por criar a API usando .Net core 3.1, usando o Entity Framework para acessar o banco de dados Sqlite.
Já o frontend, optei por utilizar o Angular na versão 9, aplicando conceitos de reactive form, interceptors e guards, sendo esses 2 últimos itens, usados na parte de autenticação e segurança. 
O projeto mobile, ainda não está feito, mas em breve, irei implementar utilizando Flutter.
Ainda pretendo adicionar mais algumas funcionalidades, como exibir as mensagens de validação nos formulários (Já estou usando as validações do Angular), adicionar componente para exibir notificações e deixar o layout responsivo.


#### Para rodar a aplicação, basta clonar ou fazer o download do projeto. É necessários ter o node instalado e o sdk do dotnet core instalado na máquina.
Para instalação do sdk do Dotnet core, basta seguir este link https://docs.microsoft.com/pt-br/dotnet/core/install/sdk?pivots=os-windows#install-alongside-visual-studio-code
Para instalar o cliente do Angular (Necessário ter o node instalado), basta seguir este link https://angular.io/guide/setup-local#step-1-install-the-angular-cli

1. Node
2. Cliente do Angular
2. Sdk do dotnet core
3. Editor de texto, utilizei o vs code.


## backend

Após baixado o projeto, abra o terminal(prompt de comando) e navegue até a pasta backend.
Dentro da pasta backend, rode no terminal o comando:
1. dotnet restore (Que irá restaurar as dependencias do projeto)
2. dotnet run (Para rodar a aplicação)

A API estará disponível em https://localhost:5001/api

Se quiser utilizar o Insomnia, use o json abaixo para importar as requisições da API deste projeto. Basta copiar o conteúdo abaixo e salvar em um arquivo json.
```
{"_type":"export","__export_format":4,"__export_date":"2020-03-28T16:56:25.693Z","__export_source":"insomnia.desktop.app:v7.1.1","resources":[{"_id":"req_532bc602bf094ad9826ed2681470f247","authentication":{},"body":{"mimeType":"application/json","text":"{\n\t\"id\": \"6042\"\n}"},"created":1585234621308,"description":"","headers":[{"id":"pair_cff3f4a0e21e4e8b88f2986c63cee683","name":"Content-Type","value":"application/json"}],"isPrivate":false,"metaSortKey":-1585234621308,"method":"POST","modified":1585234807669,"name":"Login","parameters":[],"parentId":"wrk_331ae33bb7c04e7e96c6fdad7192ac9a","settingDisableRenderRequestBody":false,"settingEncodeUrl":true,"settingFollowRedirects":"global","settingRebuildPath":true,"settingSendCookies":true,"settingStoreCookies":true,"url":"https://localhost:5001/api/session","_type":"request"},{"_id":"wrk_331ae33bb7c04e7e96c6fdad7192ac9a","created":1585181202761,"description":"","modified":1585181202761,"name":"Omnistack 11","parentId":null,"_type":"workspace"},{"_id":"req_3823979309044513a39f4e1434b5259d","authentication":{},"body":{},"created":1585234028013,"description":"","headers":[{"description":"","id":"pair_5e1a212b1a9a4bfb88c14c8d327c2848","name":"Authorization","value":"6042"}],"isPrivate":false,"metaSortKey":-1585234028013,"method":"GET","modified":1585402989892,"name":"Profile","parameters":[],"parentId":"wrk_331ae33bb7c04e7e96c6fdad7192ac9a","settingDisableRenderRequestBody":false,"settingEncodeUrl":true,"settingFollowRedirects":"global","settingRebuildPath":true,"settingSendCookies":true,"settingStoreCookies":true,"url":"https://localhost:5001/api/profile","_type":"request"},{"_id":"req_c1366e82cc6f4ea3bbe05baa593fe443","authentication":{},"body":{},"created":1585233184495,"description":"","headers":[{"description":"","id":"pair_bed20df646d547b89ef2e7c0209cf8da","name":"Authorization","value":"6042"}],"isPrivate":false,"metaSortKey":-1585233184495,"method":"DELETE","modified":1585405790916,"name":"Delete","parameters":[],"parentId":"fld_a774f9c7b6e64297bfb08c6b98c9292b","settingDisableRenderRequestBody":false,"settingEncodeUrl":true,"settingFollowRedirects":"global","settingRebuildPath":true,"settingSendCookies":true,"settingStoreCookies":true,"url":"https://localhost:5001/api/incidents/2","_type":"request"},{"_id":"fld_a774f9c7b6e64297bfb08c6b98c9292b","created":1585225968594,"description":"","environment":{},"environmentPropertyOrder":null,"metaSortKey":-1585225968594,"modified":1585225968594,"name":"Ações","parentId":"wrk_331ae33bb7c04e7e96c6fdad7192ac9a","_type":"request_group"},{"_id":"req_77f066fd2a6a43bc8e62660eccc6d0d9","authentication":{},"body":{},"created":1585233144002,"description":"","headers":[],"isPrivate":false,"metaSortKey":-1585225980330,"method":"GET","modified":1585235555146,"name":"List","parameters":[],"parentId":"fld_a774f9c7b6e64297bfb08c6b98c9292b","settingDisableRenderRequestBody":false,"settingEncodeUrl":true,"settingFollowRedirects":"global","settingRebuildPath":true,"settingSendCookies":true,"settingStoreCookies":true,"url":"https://localhost:5001/api/incidents?page=1","_type":"request"},{"_id":"req_d3bfbcf3da114c28bf6fd71235146abf","authentication":{},"body":{"mimeType":"application/json","text":"{\n\t\"title\": \"Teste\",\n\t\"description\": \"descrição\",\n\t\"value\": 100\n}"},"created":1585225980280,"description":"","headers":[{"id":"pair_d18ac079a78f440d860bd403e5284a12","name":"Content-Type","value":"application/json"},{"description":"","id":"pair_4e7685df9bef4de79e7485db0fa3baf9","name":"Authorization","value":"6042"}],"isPrivate":false,"metaSortKey":-1585225980280,"method":"POST","modified":1585226262722,"name":"Create","parameters":[],"parentId":"fld_a774f9c7b6e64297bfb08c6b98c9292b","settingDisableRenderRequestBody":false,"settingEncodeUrl":true,"settingFollowRedirects":"global","settingRebuildPath":true,"settingSendCookies":true,"settingStoreCookies":true,"url":"https://localhost:5001/api/incidents","_type":"request"},{"_id":"req_d91da524e9e744e3a6e8a27170c13e3e","authentication":{},"body":{"mimeType":"application/json","text":"{\n\t\"name\": \"APAD\",\n\t\"email\": \"contato@apad.com.br\",\n\t\"whatsapp\": \"11 93832-1231\",\n\t\"city\": \"Salto\",\n\t\"uf\": \"SP\"\n}"},"created":1585181220256,"description":"","headers":[{"id":"pair_430d7bdf604f4bac96d7ad01653eb71d","name":"Content-Type","value":"application/json"}],"isPrivate":false,"metaSortKey":-1585181220256,"method":"POST","modified":1585181325403,"name":"Create","parameters":[],"parentId":"fld_f353b24761584cecacd7276d24f6c8eb","settingDisableRenderRequestBody":false,"settingEncodeUrl":true,"settingFollowRedirects":"global","settingRebuildPath":true,"settingSendCookies":true,"settingStoreCookies":true,"url":"https://localhost:5001/api/ongs","_type":"request"},{"_id":"fld_f353b24761584cecacd7276d24f6c8eb","created":1585181208038,"description":"","environment":{},"environmentPropertyOrder":null,"metaSortKey":-1585181208038,"modified":1585181208038,"name":"Ongs","parentId":"wrk_331ae33bb7c04e7e96c6fdad7192ac9a","_type":"request_group"},{"_id":"req_e0d5ba5ed13a4243bea59bd2c17cc78c","authentication":{},"body":{},"created":1585182044821,"description":"","headers":[],"isPrivate":false,"metaSortKey":-1584922648813,"method":"GET","modified":1585182056499,"name":"List","parameters":[],"parentId":"fld_f353b24761584cecacd7276d24f6c8eb","settingDisableRenderRequestBody":false,"settingEncodeUrl":true,"settingFollowRedirects":"global","settingRebuildPath":true,"settingSendCookies":true,"settingStoreCookies":true,"url":"https://localhost:5001/api/ongs","_type":"request"},{"_id":"env_f55c3904b9b9c6b1443f6d35363d4766c2152952","color":null,"created":1585181202990,"data":{},"dataPropertyOrder":null,"isPrivate":false,"metaSortKey":1585181202990,"modified":1585181202990,"name":"Base Environment","parentId":"wrk_331ae33bb7c04e7e96c6fdad7192ac9a","_type":"environment"},{"_id":"jar_f55c3904b9b9c6b1443f6d35363d4766c2152952","cookies":[],"created":1585181202997,"modified":1585181202997,"name":"Default Jar","parentId":"wrk_331ae33bb7c04e7e96c6fdad7192ac9a","_type":"cookie_jar"}]}
```

## frontend

Após baixado o projeto, abra o terminal e navegue até a pasta do projeto frontend.
Dentro da pasta frontend, rode no terminal o comando:
1. npm install (Irá instalar as dependencias do projeto)
2. ng serve -o (Irá rodar a aplicação Angular e irá abrir a aplicação no navegador)

Qualquer dúvida, mande um e-mail jonathastassi@hotmail.com ou me procure no https://www.linkedin.com/in/jonathas-tassi-e-silva/.

