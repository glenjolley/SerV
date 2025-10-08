# SerV


This simply serves a CV, stored in a MariaDB/MySQL database, in JSON format via the /v1/cv endpoint.

Usage is /v1/cv?code= where code is an alphanumeric code in string format. The code must be valid and not expired.


## Return formats:

### CV:

| Field         | Type                          | Description                                                             |
| ------------- | ----------------------------- | ----------------------------------------------------------------------- |
| `id`          | `integer`                     | Unique identifier for the CV.                                           |
| `fullName`    | `string`                      | Full name of the person.                                                |
| `title`       | `string`                      | Professional title or current role.                                     |
| `phoneNumber` | `string`                      | Contact phone number.                                                   |
| `email`       | `string`                      | Email address.                                                          |
| `website`     | `string`                      | Personal or professional website URL.                                   |
| `linkedIn`    | `string`                      | LinkedIn profile URL.                                                   |
| `address`     | `string`                      | Physical location or address.                                           |
| `about`       | `string`                      | A short biography or description of the person’s experience and skills. |
| `experiences` | `array of Experience objects` | List of professional experiences.                                       |
| `educations`  | `array of Education objects`  | List of educational qualifications.                                     |
| `skills`      | `array of Skill objects`      | List of skills and proficiency levels.                                  |

### Experience Object:

| Field         | Type                             | Description                                                |
| ------------- | -------------------------------- | ---------------------------------------------------------- |
| `id`          | `integer`                        | Unique identifier for the experience entry.                |
| `company`     | `string`                         | Name of the company or organization.                       |
| `role`        | `string`                         | Job title or role held.                                    |
| `description` | `string`                         | Detailed description of responsibilities and achievements. |
| `dateStarted` | `string (ISO 8601 date)`         | Start date of the role. Example: `"2023-08-01T00:00:00"`.  |
| `dateEnded`   | `string (ISO 8601 date) or null` | End date of the role; `null` if currently employed.        |

### Education Object:

| Field           | Type      | Description                                          |
| --------------- | --------- | ---------------------------------------------------- |
| `id`            | `integer` | Unique identifier for the education entry.           |
| `institution`   | `string`  | Name of the school, college, or university.          |
| `qualification` | `string`  | Name or type of qualification (e.g., GCSE, A-Level). |
| `topic`         | `string`  | Subject or field of study.                           |
| `yearStarted`   | `integer` | Year education started.                              |
| `yearEnded`     | `integer` | Year education ended.                                |

### Skill Object:

| Field              | Type      | Description                                                       |
| ------------------ | --------- | ----------------------------------------------------------------- |
| `id`               | `integer` | Unique identifier for the skill entry.                            |
| `skillName`        | `string`  | Name of the skill or technology.                                  |
| `proficiencyLevel` | `string`  | Level of proficiency (e.g., Beginner, Intermediate, Experienced). |


## Hosting it yourself:

If, for some reason you'd like to host it yourself then you'll need to provide a mysql or mariadb database and provide the app with the following config options:

| Option | Type | Required/Optional | Description |
| ------ | ---- | ----------------- | ----------- |
| `DB_HOST` | `string` | `Required` | `The IP or hostname of the DB` |
| `DB_NAME` | `string` | `Required` | `Database name to be used` |
| `DB_USER` | `string` | `Required` | `User for Database access (I'd always advise against root)` |
| `DB_PASSWD` | `string` | `Required` | `Password for the above user` |
| `DB_PORT` | `string` | `Optional` | `DB port, assumed 3306 if not provided` |


Alternatively, if you have access to a private docker registry then the project works really well in a docker container (this is how I personally host it!), here's an example docker-compose.yaml:

```
services:
  serv:
    image: <your registry here>/serv:latest
    container_name: serv
    restart: unless-stopped
    ports:
      8080:8080
    environment:
      - DB_USER=serv
      - DB_PASSWD=${MYSQL_PWD}
      - DB_NAME=servdb
      - DB_HOST=servdb
  servdb:
    image: mariadb:latest
    container_name: servdb
    restart: unless-stopped
    environment:
      - MYSQL_ROOT_PASSWORD=${MYSQL_ROOT}
      - MYSQL_DATABASE=servdb
      - MYSQL_USER=serv
      - MYSQL_PASSWORD=${MYSQL_PWD}
    volumes:
      - mysql_data:/var/lib/mysql
      
volumes:
  mysql_data: null
```
