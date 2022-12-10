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
SELECT refillorders.refillorder_id,orderdetails.product_id,products.product_name,refillorders.machine_id,refillorders.order_date,orderdetails.product_price,sum(orderdetails.order_quantity) AS order_quantity, (product_price*order_quantity)AS order_totalPay,refillorders.employee_id
FROM (((products 
LEFT JOIN orderdetails ON products.product_id = orderdetails.product_id)
LEFT JOIN refillorders ON refillorders.refillOrder_id = orderdetails.refillOrder_id)
INNER JOIN employee ON employee.employee_id = refillorders.employee_id)
GROUP BY products.product_id,refillorders.machine_id;


3. Show orderdetails with product name, order prodeduct_price, order_quantity and order_date SEARCH by machine id [Done]

SELECT refillorders.refillorder_id,orderdetails.product_id,products.product_name,refillorders.machine_id,refillorders.order_date,orderdetails.product_price,sum(orderdetails.order_quantity) AS order_quantity, (product_price*order_quantity)AS order_totalPay,refillorders.employee_id
FROM (((products 
LEFT JOIN orderdetails ON products.product_id = orderdetails.product_id)
LEFT JOIN refillorders ON refillorders.refillOrder_id = orderdetails.refillOrder_id)
LEFT JOIN employee ON employee.employee_id = refillorders.employee_id)
WHERE refillorders.machine_id =1
GROUP BY products.product_id;

4. Update order product
UPDATE orderdetails o
SET o.product_id=12
        WHERE o.refillOrder_id =3 AND o.product_id =1;

5. Update order machine, employee
UPDATE refillorders r
SET r.employee_id = 1,
    r.machine_id= 1
        WHERE r.refillOrder_id =3 ;

4. Show salesdetails with machine id, product name, sales product_price, sale quantiry and sale_date group by product id [Edeted][done]


SELECT sales.sale_id,products.product_id,products.product_name,sales.machine_id,sales.sale_date,saledetails.product_price,saledetails.sale_quantity AS sale_quantity,(saledetails.product_price*saledetails.sale_quantity) AS sale_totalMoney
FROM ((products 
LEFT JOIN saledetails ON products.product_id = saledetails.product_id)
LEFT JOIN sales ON sales.sale_id = saledetails.sale_id)
WHERE saledetails.sale_quantity > 0
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

UPDATE library l, stu_book s
    SET l.book_count = l.book_count - 2,
        s.book_count = s.book_count + 2
WHERE l.id = s.book_id;






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



sring inparameter must have ''


SELECT o.product_id,p.product_name,r.machine_id,s.machine_id,o.product_price,o.order_quantity, sd.sale_quantity
        FROM ((((products p 
        LEFT JOIN orderdetails o ON p.product_id = o.product_id)
        LEFT JOIN refillorders r ON r.refillOrder_id = o.refillOrder_id)
        LEFT JOIN saledetails sd on sd.product_id = p.product_id)
        LEFT JOIN sales s ON s.sale_id =sd.sale_id)
        WHERE r.machine_id =1 ANd s.machine_id =1
        GROUP BY p.product_id,r.machine_id,s.machine_id;





        machine 1 order summary
        SELECT o.product_id,sum(o.order_quantity)
        FROM orderdetails o 
        INNER JOIN refillorders r ON r.refillOrder_id = o.refillOrder_id
        WHERE r.machine_id =1
        GROUP BY o.product_id;


        machine 1 sale summary
        SELECT p.product_id, sum(sd.sale_quantity)
        FROM products p
        LEFT JOIN saledetails sd on sd.product_id=p.product_id
        INNER JOIN sales s ON s.sale_id = sd.sale_id
        WHERE s.machine_id =1
        GROUP BY p.product_id;



       WITH sold AS (SELECT saledetails.product_id, saledetails.sale_quantity, 
                        sum(saledetails.sale_quantity) AS Qt 
                FROM saledetails
                JOIN sales
                    ON sales.sale_id = saledetails.sale_id
              WHERE sales.machine_id = 1
                GROUP BY saledetails.product_id
                )
SELECT  orderdetails.product_id, orderdetails.product_id , sum(orderdetails.order_quantity),sum(orderdetails.order_quantity)-sold.Qt
FROM orderdetails
JOIN refillorders
    ON orderdetails.refillOrder_id = refillorders.refillOrder_id
LEFT OUTER JOIN sold
    ON orderdetails.product_id  = sold.product_id
    WHERE refillorders.machine_id =1

 WITH sold AS (SELECT saledetails.product_id, saledetails.sale_quantity, 
                        sum(saledetails.sale_quantity) AS Qt 
                FROM saledetails
                JOIN sales
                    ON sales.sale_id = saledetails.sale_id
              WHERE sales.machine_id = 1
                GROUP BY saledetails.product_id
                )
SELECT  orderdetails.product_id , sum(orderdetails.order_quantity),sold.Qt,sum(orderdetails.order_quantity)-sold.Qt
FROM orderdetails
JOIN refillorders
    ON orderdetails.refillOrder_id = refillorders.refillOrder_id
LEFT OUTER JOIN sold
    ON orderdetails.product_id  = sold.product_id
    WHERE refillorders.machine_id =1
    GROUP BY orderdetails.product_id;



