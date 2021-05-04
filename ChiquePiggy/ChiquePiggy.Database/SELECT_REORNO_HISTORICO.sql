USE CHIQUEPIGGY

DECLARE @ID_CLIENTE INT = 1

SELECT C.nome, H.pontoGanhos, H.dataDaTransacao, H.valorDaCompra FROM historico H (NOLOCK)
INNER JOIN cliente C (NOLOCK)
ON H.idCliente = C.idCliente
WHERE H.idCliente = @ID_CLIENTE