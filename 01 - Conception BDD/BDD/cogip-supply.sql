-- table supplier => fournisseur
-- table sale_offer => info proposition fait par fournisseur
-- table item => info des produits cogip
-- table order => commande auprès fournisseur
-- table order_line => info commande 1 article
-- info fournisseur qui liver en <= 15j
select
    "name",
    address,
    postal_code,
    city,
    contact_name,
    satisfaction_index
from
    supplier s
    join sale_offer so on so.supplier_id = s.id
where
    delivery_time <= 15;

-- info fournisseur propose +2 articles différents (id !=)
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

-- info commande pas totalement livrées
select
    o.id,
    o.supplier_id,
    o."date",
    o."comments"
from
    "order" o
    join order_line ol on o.id = ol.order_id
where
    ordered_quantity != delivered_quantity;

-- info item proposés par bicobol
select
    i.id,
    i.item_code,
    i."name",
    i.stock_alert,
    i.stock,
    i.yearly_consumption,
    i.unit
from
    item i
    join sale_offer so on so.item_id = i.id
where
    so.supplier_id = (
        select
            id
        from
            supplier s
        where
            "name" = 'DICOBOL'
    );

-- info commande passées entre 10/01/2021 et 20/01/2021
select
    o.id,
    o.supplier_id,
    o."date",
    o."comments"
from
    "order" o
where
    extract(
        day
        from
            "date"
    ) > 10
    and extract(
        day
        from
            "date"
    ) < 20;

-- info commande où il y a + 2 items
select
    o.id,
    o.supplier_id,
    o."date",
    o."comments"
from
    "order" o
where
    o.id in (
        select
            ol.order_id
        from
            order_line ol
        group by
            ol.order_id
        having
            count(ol.item_id) > 2
    );

-- info commande & délai de livraison prévu pour livraisons < 15 j
select
    o.id,
    o.supplier_id,
    o."date",
    o."comments",
    so.delivery_time
from
    "order" o
    join supplier s on o.supplier_id = s.id
    join sale_offer so on s.id = so.supplier_id
where
    so.delivery_time < 15;

-- info commande où stock < alert
select
    o.id,
    o.supplier_id,
    o."date",
    o."comments"
from
    "order" o
    join order_line ol on o.id = ol.order_id
    join item i on i.id = ol.item_id
where
    i.stock < i.stock_alert;

-- info fournisseur reçu + 10 000 000 par cogip
select
    s.id,
    s."name",
    s.address,
    s.postal_code,
    s.city,
    s.contact_name,
    s.satisfaction_index
from
    supplier s
where
    s.id in (
        select
            o.supplier_id
        from
            "order" o
        where
            o.id in (
                select
                    ol.order_id
                from
                    order_line ol
                group by
                    ol.order_id
                having
                    sum(ol.unit_price * ol.delivered_quantity) > 10000000
            )
    );

-- info fournisseurs prix + bas pour chaque item
select
    s.id,
    s."name",
    s.address,
    s.postal_code,
    s.city,
    s.contact_name,
    s.satisfaction_index,
    so.item_id
from
    supplier s
    join sale_offer so on so.supplier_id = s.id
where
    so.price = (
        select
            min(so2.price)
        from
            sale_offer so2
        where
            so.item_id = so2.item_id
    );