# vendingMsh
Vending Machine inventory DB system

Introduction
Assuming that all the machines have the same products and all initial quantity of stock is 0.
There is no starting stock in each machine and stock management, if there is enought time, two more tables will be added on the DB data to show the stock information directly, but now it is managed in C#. 

Database
[]Tables

[]Quaries that may be needed

1. Show product's order history and sale history with date, current stock, group by product id, SEARCH bY machine id [Done]


SELECT products.product_id,orderdetails.orderDetail_id,refillorders.order_date,orderdetails.order_quantity,saledetails.sale_id,sales.sale_date,saledetails.sale_quantity,(orderdetails.order_quantity-sale_quantity)AS CurrentStock 
FROM ((((products 
LEFT JOIN saledetails ON products.product_id = saledetails.product_id)
LEFT JOIN orderdetails ON products.product_id = orderdetails.product_id)
LEFT JOIN sales ON sales.sale_id = saledetails.sale_id)
LEFT JOIN refillorders ON refillorders.refillOrder_id = orderdetails.refillOrder_id)
WHERE refillorders.machine_id = 1
GROUP BY product_id;


2. Show orderdetails with machine id, product name, order product price, order quantity, total order money and order date[Done]
SELECT orderdetails.product_id,products.product_name,refillorders.machine_id,refillorders.order_date,orderdetails.product_price,sum(orderdetails.order_quantity) AS OrderQuantity, (product_price*order_quantity)AS TotalMoney,refillorders.employee_id
FROM (((products 
LEFT JOIN orderdetails ON products.product_id = orderdetails.product_id)
LEFT JOIN refillorders ON refillorders.refillOrder_id = orderdetails.refillOrder_id)
INNER JOIN employee ON employee.employee_id = refillorders.employee_id)
GROUP BY products.product_id,refillorders.machine_id;


3. Show orderdetails with product name, order prodeduct_price, order_quantity and order_date SEARCH by machine id [Done]

SELECT orderdetails.product_id,products.product_name,refillorders.order_date,orderdetails.product_price,sum(orderdetails.order_quantity) AS OrderQuantity, (product_price*order_quantity)AS TotalMoney, refillorders.employee_id
FROM (((products 
LEFT JOIN orderdetails ON products.product_id = orderdetails.product_id)
LEFT JOIN refillorders ON refillorders.refillOrder_id = orderdetails.refillOrder_id)
LEFT JOIN employee ON employee.employee_id = refillorders.employee_id)
WHERE refillorders.machine_id =1
GROUP BY products.product_id;

4. Show salesdetails with machine id, product name, sales product_price, sale quantiry and sale_date group by product id [Done]


SELECT products.product_id,products.product_name,sales.machine_id,sales.sale_date,saledetails.product_price,sum(saledetails.sale_quantity) AS TotalQuantity,(saledetails.product_price*SUM(saledetails.sale_quantity)) AS TotalMoney
FROM ((products 
LEFT JOIN saledetails ON products.product_id = saledetails.product_id)
LEFT JOIN sales ON sales.sale_id = saledetails.sale_id)
GROUP BY products.product_id,sales.machine_id;



5. Show salesdetails with the product name, sales product_price, sale quantiry and sale_date group by product id SEARCH by machine id [Done]

SELECT products.product_id,products.product_name,sales.sale_date,saledetails.product_price,sum(saledetails.sale_quantity) AS TotalQuantity,(saledetails.product_price*SUM(saledetails.sale_quantity)) AS TotalMoney
FROM ((products 
LEFT JOIN saledetails ON products.product_id = saledetails.product_id)
LEFT JOIN sales ON sales.sale_id = saledetails.sale_id)
WHERE sales.machine_id =1
GROUP BY products.product_id;

6. Add order

7. Add sales

8. Uppdate products








8. Show all the products oder quantity, price, vending machine and total order money group by product_id, machine_id. 
SELECT products.product_id,products.product_name, machines.machine_id,orderdetails.product_price,sum(order_quantity), sum(product_price*order_quantity),refillorders.employee_id 
FROM ((((orderdetails 
INNER JOIN products ON products.product_id = orderdetails.product_id) 
INNER JOIN refillorders ON refillorders.refillOrder_id = orderdetails.refillOrder_id)
INNER JOIN machines ON machines.machine_id = refillorders.machine_id)
INNER JOIN employee ON employee.employee_id = refillorders.employee_id)
GROUP BY products.product_id,machines.machine_id;

9. Show all the salese products,quantity and money by machine ID  [Done]
SELECT saledetails.product_id,products.product_name,saledetails.product_price,sum(saledetails.sale_quantity) AS TotalQuantity,(saledetails.product_price*sum(saledetails.sale_quantity)) AS TotalMoney
FROM ((saledetails
INNER JOIN sales ON saledetails.sale_id = sales.sale_id)
INNER JOIN products ON products.product_id = saledetails.product_id)
WHERE sales.machine_id =3
GROUP BY saledetails.product_id; 



