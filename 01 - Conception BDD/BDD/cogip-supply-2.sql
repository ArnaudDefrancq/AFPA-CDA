create or replace function format_date(date date, separator varchar) returns text language plpgsql as $$ 
begin 
return to_char(
    "date",
    'DD' || separator || 'MM' || separator || 'YYYY'
);
end;
$$

select format_date('2023-02-01', '/');

create or replace function display_order() returns text language plpgsql as $$ 
declare 
    string_result text;

i int;

begin string_result := '';

for i in
select
    id
from
    "order" o loop raise notice 'string_result : %',
    string_result;

string_result := string_result || '-' || i;

end loop;

return string_result;

end;

$ $
select
    o.id,
    o.supplier_id,
    format_date(o."date", '-'),
    o."comments"
from
    "order" o;

select
    display_order();

create
or replace function get_items_count() returns int language plpgsql as $ $ declare items_count int;

time_now time = now();

begin
select
    count(id) into items_count
from
    item;

raise notice '% articles à %',
items_count,
time_now;

return items_count;

end;

$ $
select
    get_items_count();

create
or replace function count_items_to_order() returns int language plpgsql as $ $ declare alert int;

i record;

i_1 int;

i_2 int;

begin alert := 0;

for i in
select
    id,
    stock,
    stock_alert
from
    item loop if i.stock < i.stock_alert then alert := alert + 1;

end if;

raise notice '% alert',
alert;

end loop;

return alert;

end;

$ $
select
    count_items_to_order();

create
or replace function best_supplier() returns text language plpgsql as $ $ declare begin
end;

$ $
select
    supplier_id,
    count(id)
from
    "order"
group by
    supplier_id;