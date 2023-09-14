-- liste hotels
select
    h."name",
    h.city
from
    hotel h;

-- ville résidence Mr White
select
    c.first_name,
    c.last_name,
    c."address",
    c.city
from
    client c
where
    c.last_name like 'White';

-- liste station => altitude < 1000
select
    s."name",
    s.altitude
from
    station s
where
    s.altitude < 1000;

-- liste chambre capacité > 1
select
    r."number",
    r.capacity
from
    room r
where
    r.capacity > 1;

-- client city != londres
select
    c.last_name,
    c.city
from
    client c
where
    c.city != 'Londres';

-- liste hotels située a Bretou et category > 3
select
    h."name",
    h.city,
    h.category
from
    hotel h
where
    h.city like 'Bretou'
    and h.category > 3;

-- liste hotel avec leur station
select
    s."name",
    h."name",
    h.city,
    h.category
from
    station s
    join hotel h on s.id = h.station_id;

-- liste chambre et leur hostel
select
    h."name",
    h.category,
    h.city,
    r."number"
from
    hotel h
    join room r on h.id = r.hotel_id;

-- liste chambre > 1 place dans hotel situé a bretou
select
    h."name",
    h.category,
    h.city,
    r."number",
    r.capacity
from
    hotel h
    join room r on h.id = r.hotel_id
where
    r.capacity > 1
    and h.city like 'Bretou';

--liste reservation + nom client
select
    c.last_name,
    h."name",
    b.booking_date
from
    hotel h
    join room r on h.id = r.hotel_id
    join booking b on r.id = b.room_id
    join client c on b.client_id = c.id;

-- liste chambre + nom hostel + nom station
select
    s."name",
    h."name",
    r."number",
    r.capacity
from
    station s
    join hotel h on s.id = h.station_id
    join room r on r.hotel_id = h.id;

-- reservation + nom client + nom hotel
select
    c.last_name,
    h."name",
    b.stay_start_date,
    b.stay_end_date - b.stay_start_date as time_booking
from
    hotel h
    join room r on r.hotel_id = h.id
    join booking b on b.room_id = r.id
    join client c on c.id = b.client_id;

-- compter nombre hotel / station
select
    h.station_id,
    count(h."name") as nb_hotel
from
    hotel h
group by
    h.station_id;

-- compter nb room / station
select
    h.station_id,
    count(r.id) as nb_room_hotel
from
    hotel h
    join room r on r.hotel_id = h.id
group by
    h.station_id;

-- compter nb room / station capacité > 1
select
    h.station_id,
    count(r.id) as nb_room_hotel
from
    hotel h
    join room r on h.id = r.hotel_id
where
    r.capacity > 1
group by
    h.station_id;

-- liste hotel où Squire a fait une reservation
select
    r.hotel_id
from
    room r
    join booking b on b.room_id = r.id
    join client c on c.id = b.client_id
where
    c.last_name like 'Squire';

-- create view
create
or replace view hotel_station as
select
    h.id as hotel_id,
    h.station_id,
    h."name" as hotel_name,
    h.category,
    h.address,
    h.city,
    s."name" as station_name,
    s.altitude
from
    hotel h
    join station s on h.station_id = s.id;

select
    *
from
    hotel_station hs;

-- view reservation + client
create
or replace view reservation_client as
select
    b.id as reservation_id,
    c.last_name
from
    booking b
    join client c on b.client_id = c.id;

-- liste chambre + nom hotel + nom station
create
or replace view list_room as
select
    r.id as room_id,
    h."name" as name_hotel,
    s."name" as name_station
from
    room r
    join hotel h on h.id = r.hotel_id
    join station s on h.station_id = s.id;

-- liste reservation +nom client + nom hotel
create
or replace view list_reservation_hotel as
select
    b.id as reservation_id,
    c.last_name as nom_client,
    h."name" as nom_hotel
from
    booking b
    join client c ON c.id = b.client_id
    join room r on b.room_id = r.id
    join hotel h on r.hotel_id = h.id;

select
    rolname
from
    pg_roles;

create role application_client login password 'arnaud';

grant all on booking,
client,
hotel,
room to application_admin;