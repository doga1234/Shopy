
CREATE VIEW Ürünler
AS
SELECT U.ürünAdı, B.stokMiktarı, K.bedenAdı, U.fiyat, M.boy, M.kilo
FROM Ürün AS U, ÜrünBeden AS B, Beden AS K, Manken as M
WHERE
U.ürünID =B.ürünID AND 
K.BedenID =B.BedenID AND
M.mankenID=B.mankenID AND
B.stokMiktarı>0;
go;
CREATE PROC Ürünler_
AS
SELECT U.ürünAdı, B.stokMiktarı, K.bedenAdı, U.fiyat, M.boy, M.kilo
FROM Ürün AS U, ÜrünBeden AS B, Beden AS K, Manken as M
WHERE
U.ürünID =B.ürünID AND 
K.BedenID =B.BedenID AND
M.mankenID=B.mankenID AND
B.stokMiktarı>0;