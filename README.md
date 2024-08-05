# Delivery Store Web Api
API RESTFul para o gerenciamento das vendas de uma loja delivery.

Features:

1. Gerenciamento de Produtos
2. Criação de Vendas
3. Cancelamento de Vendas
4. Consulta de Histórico de Vendas
5. Cálculo de Frete



# Executando app Delivery Store API com Docker

> Para criar imagem Docker: 
docker build -t delivery-store-api-image -f  DeliveryStoreWebApi/Dockerfile .

> Para executar o App
docker run --rm -p 4000:44356 delivery-store-api-image -e "ASPNETCORE_ENVIRONMENT=Development"

> Acessar web
http://localhost:4000/swagger/index.html