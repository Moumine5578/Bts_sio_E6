#!/bin/sh
echo "### RSYNC ###"
rsync  -e 'ssh -X' -S -av ./ DanoisTimeo@172.16.128.51:/var/www/TardyGrade  --include="public/.htaccess" --include=".env"  --include=".env.vm.local" --exclude-from=".gitignore" --exclude=".*"
echo "### CONNECTION SSH ###"
ssh DanoisTimeo@172.16.128.51 -o "StrictHostKeyChecking=no" <<'eof'
echo "### CD cd /var/www/TardyGrade ###"
cd /var/www/TardyGrade
echo "### RENOMMAGE .env.local ###"
mv .env.vm.local .env.local
echo "### COMPOSER INSTALL ###"
composer install
echo "### DOCTRINE MIGRATION ###"
symfony console --no-interaction doctrine:database:create --if-not-exists
symfony console --no-interaction doctrine:migrations:migrate