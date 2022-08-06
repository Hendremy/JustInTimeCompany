Pour construire la BD locale:

1) Appliquer migrations jusqu'à la migration PathKey

update-database PathKey

2) Lancer 1 fois l'application pour Seeder les utilisateurs

3) Appliquer le reste des migrations

update-database