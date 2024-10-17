#!/bin/sh
composer install
php artisan down
php artisan migrate:fresh --seed
php artisan up
php-fpm