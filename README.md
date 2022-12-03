# vendingMsh
Vending Machine inventory DB system

Introduction
Assuming that all the machines have the same products
There is no starting stock in each machine and stock management, if there is enought time, two more tables will be added on the DB data to show the stock information directly, but now it is managed in C#. 

Database
[]Tables
[]Quaries that may be needed
1. Show product's order history and sale history with date, machine_id product's name and quantity 

SELECT products.product_id,orderdetails.orderDetail_id,refillorders.order_date,refillorders.machine_id,orderdetails.order_quantity,saledetails.sale_id,sales.sale_date,sales.machine_id,saledetails.sale_quantity 
FROM ((((products 
INNER JOIN saledetails ON products.product_id = saledetails.product_id)
INNER JOIN orderdetails ON products.product_id = orderdetails.product_id)
INNER JOIN sales ON sales.sale_id = saledetails.sale_id)
INNER JOIN refillorders ON refillorders.refillOrder_id = orderdetails.refillOrder_id);


2. Show orderdetails with machine id, product name, order product price, order quantity, total order money and order date
SELECT refillorders.machine_id,refillorders.order_date,orderdetails.product_id,products.product_name,orderdetails.product_price,orderdetails.order_quantity, (product_price*order_quantity)
FROM ((products 
INNER JOIN orderdetails ON products.product_id = orderdetails.product_id)
INNER JOIN refillorders ON refillorders.refillOrder_id = orderdetails.refillOrder_id);


3. Show orderdetails with machine id, product name, order prodeduct_price, order_quantity and order_date

SELECT refillorders.machine_id,products.product_name,refillorders.order_date,orderdetails.product_price,orderdetails.order_quantity
FROM ((products 
INNER JOIN orderdetails ON products.product_id = orderdetails.product_id)
INNER JOIN refillorders ON refillorders.refillOrder_id = orderdetails.refillOrder_id);

4. Show salesdetails with machine id, product name, sales product_price, sale:quantiry and sale_date

SELECT sales.machine_id,products.product_name,sales.sale_date,saledetails.product_price,saledetails.sale_quantity,(product_price*sale_quantity)
FROM ((products 
INNER JOIN saledetails ON products.product_id = saledetails.product_id)
INNER JOIN sales ON sales.sale_id = saledetails.sale_id);


5. Show all the products sales quantity and total money group by products id

SELECT saledetails.product_id,products.product_name,saledetails.product_price,sum(sale_quantity), sum(product_price*sale_quantity) 
FROM products 
LEFT JOIN saledetails ON products.product_id = saledetails.product_id
GROUP BY products.product_id;

6. Show all the products order quantity, price and money group bu product id
SELECT orderdetails.product_id,products.product_name, orderdetails.product_price,sum(order_quantity), sum(product_price*order_quantity) 
FROM products 
LEFT JOIN orderdetails ON products.product_id = orderdetails.product_id
GROUP BY products.product_id;


7. Show all the products sales quantity, price, vending machine and total sales money group by product_id, machine_id. 

SELECT products.product_id,products.product_name, machines.machine_id,saledetails.product_price,sum(sale_quantity), sum(product_price*sale_quantity) 
FROM (((saledetails 
INNER JOIN products ON products.product_id = saledetails.product_id) 
INNER JOIN sales ON sales.sale_id = saledetails.sale_id)
INNER JOIN machines ON machines.machine_id = sales.machine_id) 
GROUP BY products.product_id,machines.machine_id;


8. Show all the products oder quantity, price, vending machine and total order money group by product_id, machine_id. 
SELECT products.product_id,products.product_name, machines.machine_id,orderdetails.product_price,sum(order_quantity), sum(product_price*order_quantity),refillorders.employee_id 
FROM ((((orderdetails 
INNER JOIN products ON products.product_id = orderdetails.product_id) 
INNER JOIN refillorders ON refillorders.refillOrder_id = orderdetails.refillOrder_id)
INNER JOIN machines ON machines.machine_id = refillorders.machine_id)
INNER JOIN employee ON employee.employee_id = refillorders.employee_id)
GROUP BY products.product_id,machines.machine_id;

