--PRACTICA SQL

--1
SELECT clie_codigo, clie_razon_social 
FROM 
	gdd_practica.dbo.Cliente 
WHERE
	clie_limite_credito >= 1000
ORDER BY
	clie_codigo 

--2
SELECT prod_codigo, prod_detalle
FROM 
	gdd_practica.dbo.Item_Factura fi INNER JOIN
	gdd_practica.dbo.Factura fa
	ON fa.fact_tipo = fi.item_tipo AND fa.fact_numero = fi.item_numero
	AND fa.fact_sucursal = fi.item_sucursal
	INNER JOIN gdd_practica.dbo.Producto p
	ON fi.item_producto = prod_codigo
GROUP BY p.prod_codigo, p.prod_detalle, fa.fact_fecha
HAVING YEAR(fa.fact_fecha) = 2012
ORDER BY SUM(fi.item_cantidad) DESC