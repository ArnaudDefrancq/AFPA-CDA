-- 1
select
    first_name,
    encode(digest('test11', 'sha1'), 'hex'),
    "password"
from
    client
where
    first_name like 'Muriel';

-- 2
select
    last_name,
    count(*)
from
    order_line ol
group by
    last_name
having
    count(*) >= 2;

-- 3
update
    order_line
set
    total_price = quantity * unit_price;

-- 4
select
    ol.total_price,
    co.purchase_date,
    c.last_name,
    c.first_name
from
    order_line ol
    join customer_order co on ol.order_id = co.id
    join client c on co.client_id = c.id;

-- 5
select
    extract(
        month
        from
            purchase_date
    ) as "month",
    count(
        extract(
            month
            from
                purchase_date
        )
    ) as totalMonth,
    sum(total_price)
from
    order_line ol
    join customer_order co on ol.order_id = co.id
group by
    "month";

-- 6
-- 7
-- 8
-- 9
-- finir exo 6
-- select 
-- *
-- from order_line ol 
-- join customer_order co 
-- on ol.order_id = co.id 
-- join client c 
-- on co.client_id = c.id;
-- select 
-- co.client_id
-- from order_line ol 
-- join customer_order co 
-- on ol.order_id = co.id
-- join client c 
-- on co.client_id =c.id
-- ;
-- select
-- client_id
-- from customer_order co ;
-- select c.last_name ,count(co.client_id), sum(ol.total_price) from order_line ol 
-- join customer_order co 
-- on ol.order_id = co.id
-- join client c 
-- on co.client_id =c.id
-- group by c.last_name;