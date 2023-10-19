# Maximum

Реализовать получение данных с сервера (asp.net core, net7) на клиент (console, net7) по rest
- все
- герои вселенной
- самый сильный герой вселенной

На сервере для хранения и получения данных использовать ORM EfCore, провайдер - InMemory (or SQLite), 

Схема данных:
- сущность universe  (string name)
- сущность superhero (string name, int power)

Начальный seed данных (universe, name, power):
    ('DC', 'Superman', 100),
    ('DC', 'Aquaman', 75),
    ('DC', 'Batman', 40),
    ('DC', 'Catwoman', 35),
    ('DC', 'Supergirl', 60),
    ('Marvel', 'Iron Man', 85),
    ('Marvel', 'Thor', 100),
    ('Marvel', 'Wolverine', 50),
    ('Marvel', 'Hulk', 70)
