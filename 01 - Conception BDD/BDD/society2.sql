-- 1 
select
    *
from
    employee e
    join department d on e.department_id = d.id;

-- 2
select
    department_id,
    name,
    last_name
from
    employee e
    join department d on e.department_id = d.id
where
    department_id > 0;

-- 3
select
    last_name
from
    employee e
    join department d on e.department_id = d.id
where
    name = 'distribution';

-- 4
select
    e1.last_name,
    e1.salary,
    e2.last_name,
    e2.salary
from
    employee e1
    join employee e2 on e1.id = e2.superior_id
where
    e1.salary < e2.salary;

-- 5
select
    *
from
    employee e
where
    department_id in (
        select
            id
        from
            department d
        where
            name like 'finance'
    );

-- 6
select
    last_name,
    title
from
    employee e
where
    title in (
        select
            title
        from
            employee e2
        where
            last_name like 'amartakaldire'
    );

-- 7
select
    e.last_name,
    e.salary,
    e.department_id
from
    employee e
where
    salary > any (
        select
            salary
        from
            employee e2
        where
            department_id = 31
    );

-- 8
select
    e.last_name,
    e.salary,
    e.department_id
from
    employee e
where
    salary > all (
        select
            salary
        from
            employee e2
        where
            department_id = 31
    );

-- 9
select
    e.last_name,
    e.title
from
    employee e
where
    department_id = 31
    and title = (
        select
            title
        from
            employee e2
        where
            department_id = 32
    );

-- 10
select
    e.last_name,
    e.title
from
    employee e
where
    department_id = 31
    and title not in (
        select
            title
        from
            employee e2
        where
            department_id = 32
    );

-- 11
select
    e.last_name,
    e.title,
    e.salary
from
    employee e
where
    title = (
        select
            title
        from
            employee e3
        where
            last_name like 'fairent'
    )
    and salary = (
        select
            salary
        from
            employee e2
        where
            last_name like 'fairent'
    );

-- 12
select
    d.id,
    name,
    last_name
from
    employee e
    right join department d on e.department_id = d.id;

-- 13
select
    avg(salary)
from
    employee e
where
    title like 'secrétaire';

-- 14
select
    count(title),
    title
from
    employee e
group by
    title;

-- 15
select
    avg(salary),
    sum(salary)
from
    employee e
    join department d on e.department_id = d.id
group by
    region_id;

-- 16
select
    department_id,
    count(*)
from
    employee e
group by
    department_id
having
    count(*) >= 3;

-- 17
select
    substring(last_name, 0, 2) as inital,
    count(*)
from
    employee e
group by
    inital
having
    count(*) >= 3;

-- 18
select
    max(salary),
    min(salary),
    max(salary) - min(salary) as "diff"
from
    employee e;

-- 19
select
    count(distinct title)
from
    employee e;

-- 20
-- comme le 14
-- 21
select
    name,
    count(*)
from
    employee e
    right join department d on e.department_id = d.id
group by
    name;

-- 22
select
    title,
    avg(salary)
from
    employee e
where
    salary > (
        select
            avg(salary)
        from
            employee e2
        where
            title like 'représentant'
    )
group by
    title;

-- 23
select
    count(distinct salary) as nombreSalaire,
    count(distinct commission_rate) as nombreCommission
from
    employee e;