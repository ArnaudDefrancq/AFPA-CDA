-- 1
select
    *
from
    supplier s
    join sale_offer so on so.supplier_id = s.id
where
    delivery_time <= 15;

-- 2
select
    name,
    address,
    postal_code,
    city,
    contact_name,
    satisfaction_index
from
    supplier s
where
    (
        select
            count(so2.item_id)
        from
            sale_offer so2
        where
            s.id = so2.supplier_id
    ) > 2;

-- 3
-- 4
-- 5
-- 6
-- 7
-- 8
-- 9
-- 10