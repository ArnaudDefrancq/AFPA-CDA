-- 1
SELECT
    *
FROM
    employee;

-- 2
select
    *
from
    department;

--3
select
    last_name,
    hiring_date,
    superior_id,
    department_id,
    salary
from
    employee;

--4
select
    title
from
    employee;

--5
select
    distinct title
from
    employee;

--6
select
    *
from
    employee
where
    salary > 25000;

--7
select
    last_name,
    id,
    department_id
from
    employee
where
    title = 'secrétaire';

-- 8
select
    last_name,
    department_id
from
    employee
where
    department_id > 40;

-- 9 
select
    last_name,
    first_name
from
    employee
order by
    first_name desc;

-- 10
select
    last_name,
    salary,
    department_id
from
    employee
where
    title = 'représentant'
    and department_id = 35
    and salary > 20000;

-- 11
select
    last_name,
    title,
    salary
from
    employee
where
    title = 'représentant'
    or title = 'président';

-- 12
select
    last_name,
    title,
    department_id,
    salary
from
    employee
where
    department_id = 34
    and title = 'représentant'
    or title = 'secrétaire';

-- 13
select
    last_name,
    title,
    department_id,
    salary
from
    employee
where
    title = 'représentant'
    or title = 'secrétaire'
    and department_id = 34;

--14
select
    last_name,
    salary
from
    employee
where
    salary between 20000
    and 30000;

-- 15
select
    last_name
from
    employee
where
    last_name like 'h%';

-- 16
select
    last_name
from
    employee
where
    last_name like '%n';

-- 17
select
    last_name
from
    employee
where
    last_name like '__u%';

--18
select
    salary,
    last_name
from
    employee
where
    department_id = 41
order by
    salary asc;

-- 19
select
    salary,
    last_name
from
    employee
where
    department_id = 41
order by
    salary desc;

-- 20
select
    title,
    salary,
    last_name
from
    employee
order by
    title asc,
    salary desc;

-- 21
select
    commission_rate,
    salary,
    last_name
from
    employee
order by
    commission_rate asc;

-- 22
select
    last_name,
    salary,
    commission_rate,
    title
from
    employee
where
    commission_rate is null;

-- 23
select
    last_name,
    salary,
    commission_rate,
    title
from
    employee
where
    commission_rate is not null;

-- 24
select
    last_name,
    salary,
    commission_rate,
    title
from
    employee
where
    commission_rate < 15;

--25 
select
    last_name,
    salary,
    commission_rate,
    title
from
    employee
where
    commission_rate > 15;

-- 26
select
    last_name,
    salary,
    commission_rate,
    commission_rate * salary as "commission"
from
    employee
where
    commission_rate is not null;

-- 27
select
    last_name,
    salary,
    commission_rate,
    commission_rate * salary as "commission"
from
    employee
where
    commission_rate is not null
order by
    commission_rate asc;

-- 28
select
    concat(last_name, ' ', first_name) as "nom_prenom"
from
    employee;

-- 29
select
    substring(last_name, 0, 6)
from
    employee;

-- 30
select
    position('r' in last_name)
from
    employee;

-- 31
select
    last_name,
    lower(last_name),
    upper(last_name)
from
    employee
where
    last_name = 'vrante';

-- 32
select
    last_name,
    length(last_name)
from
    employee;