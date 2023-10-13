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
select
    c.id,
    sum(total_price) as sum_total_price
from
    order_line ol
    join customer_order co on ol.order_id = co.id
    join client c on co.client_id = c.id
group by
    c.id
order by
    sum_total_price desc
limit
    10;

-- 7
select
    extract(
        doy
        from
            purchase_date
    ) as "day",
    sum(total_price) as sum_day
from
    order_line ol
    join customer_order co on ol.order_id = co.id
group by
    "day";

-- 8
alter table
    customer_order
add
    column category int;

-- 9
UPDATE
    customer_order AS co
SET
    category = CASE
        WHEN total_price < 200 THEN 1
        WHEN total_price >= 200
        AND total_price < 500 THEN 2
        WHEN total_price >= 500
        AND total_price < 1000 THEN 3
        WHEN total_price >= 1000 THEN 4
    END
FROM
    (
        SELECT
            co.id AS order_id,
            SUM(ol.total_price) AS total_price
        FROM
            order_line AS ol
            JOIN customer_order AS co ON ol.order_id = co.id
        GROUP BY
            co.id
    ) AS order_totals
WHERE
    co.id = order_totals.order_id;