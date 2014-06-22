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

--3
SELECT prod_codigo, prod_detalle, ISNULL(SUM(stoc_cantidad),0)
FROM gdd_practica.dbo.Producto LEFT JOIN gdd_practica.dbo.STOCK ON prod_codigo = stoc_producto
GROUP BY prod_codigo, prod_detalle
ORDER BY prod_detalle ASC

--4
SELECT prod_codigo, prod_detalle, COUNT(comp_componente)
FROM (gdd_practica.dbo.Producto LEFT JOIN gdd_practica.dbo.STOCK 
	ON prod_codigo = stoc_producto) LEFT JOIN gdd_practica.dbo.Composicion
	ON prod_codigo = comp_producto
GROUP BY prod_codigo, prod_detalle
HAVING AVG(stoc_cantidad) > 100

--5
SELECT prod_codigo, prod_detalle, SUM(item_cantidad)
FROM gdd_practica.dbo.Producto INNER JOIN gdd_practica.dbo.Item_Factura ifi
	ON prod_codigo = item_producto INNER JOIN gdd_practica.dbo.Factura
	ON item_tipo = fact_tipo AND item_sucursal = fact_sucursal
	AND item_numero = fact_numero
GROUP BY prod_codigo, prod_detalle
HAVING (SELECT COUNT(*) FROM gdd_practica.dbo.Item_Factura ift INNER JOIN gdd_practica.dbo.Factura ft ON 
	ft.fact_tipo = ift.item_tipo AND ft.fact_sucursal = ift.item_sucursal AND ft.fact_numero = ift.item_numero
	WHERE ift.item_producto = prod_codigo AND YEAR(fact_fecha) = 2012) > 
	(SELECT COUNT(*) FROM gdd_practica.dbo.Item_Factura ift INNER JOIN gdd_practica.dbo.Factura ft ON 
	ft.fact_tipo = ift.item_tipo AND ft.fact_sucursal = ift.item_sucursal AND ft.fact_numero = ift.item_numero
	WHERE ift.item_producto = prod_codigo AND YEAR(fact_fecha) = 2011)

--6
SELECT rubr_detalle,COUNT(prod_codigo), ISNULL(SUM(stoc_cantidad),0)
FROM (gdd_practica.dbo.Rubro LEFT JOIN gdd_practica.dbo.Producto
	ON rubr_id = prod_rubro) LEFT JOIN gdd_practica.dbo.STOCK
	ON prod_codigo = stoc_producto
WHERE stoc_cantidad > (SELECT stoc_cantidad FROM gdd_practica.dbo.STOCK stb WHERE stb.stoc_producto = '00000000'
	AND stb.stoc_deposito = '00')
GROUP BY rubr_id, rubr_detalle

--7
SELECT prod_codigo, prod_detalle, ISNULL(MAX(item_precio),prod_precio), ISNULL(MIN(item_precio),prod_precio),
 ISNULL((((MAX(item_precio) - MIN(item_precio)) / MAX(item_precio)) * 100),0)
FROM gdd_practica.dbo.Producto INNER JOIN gdd_practica.dbo.STOCK ON 
	prod_codigo = stoc_producto AND stoc_cantidad > 0 LEFT JOIN
	gdd_practica.dbo.Item_Factura ON prod_codigo = item_producto
GROUP BY prod_codigo, prod_detalle, prod_precio

--8
SELECT prod_detalle, MAX(stoc_cantidad)
FROM gdd_practica.dbo.Producto INNER JOIN gdd_practica.dbo.STOCK ON prod_codigo = stoc_producto
GROUP BY prod_detalle,prod_codigo
HAVING COUNT(stoc_deposito) = (SELECT COUNT(*) FROM gdd_practica.dbo.DEPOSITO)

--9
SELECT empl_codigo, empl_jefe, RTRIM(empl_apellido)+', '+RTRIM(empl_nombre), 
	(SELECT COUNT(1) FROM gdd_practica.dbo.DEPOSITO WHERE depo_encargado = empl_codigo OR depo_encargado = empl_jefe)
FROM gdd_practica.dbo.Empleado WHERE empl_jefe IS NOT NULL

--10
SELECT prod_codigo, fact_cliente, SUM(item_cantidad) FROM 
	(SELECT prod_codigo FROM gdd_practica.dbo.Producto WHERE prod_codigo IN 
	(SELECT TOP 10 item_producto FROM gdd_practica.dbo.Item_Factura
	GROUP BY item_producto ORDER BY SUM(item_cantidad) DESC)
	UNION
	SELECT prod_codigo FROM gdd_practica.dbo.Producto WHERE prod_codigo IN 
	(SELECT TOP 10 item_producto FROM gdd_practica.dbo.Item_Factura GROUP BY item_producto ORDER BY SUM(item_cantidad) ASC)) AS productos
INNER JOIN gdd_practica.dbo.Item_Factura ON item_producto = productos.prod_codigo
INNER JOIN gdd_practica.dbo.Factura ON fact_tipo = item_tipo AND fact_sucursal = item_sucursal AND fact_numero = item_numero
GROUP BY prod_codigo, fact_cliente
ORDER BY prod_codigo, SUM