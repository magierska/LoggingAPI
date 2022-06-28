CREATE TABLE application
(
    id   SERIAL,
    name TEXT,

    PRIMARY KEY (id)
);

CREATE INDEX IF NOT EXISTS idx_application_name ON application (name);

CREATE TYPE LOGLEVEL AS ENUM ('trace', 'debug', 'info', 'warn', 'error');

CREATE TABLE logmessage
(
    id             SERIAL,
    application_id SERIAL,
    date           TIMESTAMP,
    message        TEXT,
    log_level      LOGLEVEL,

    PRIMARY KEY (id),
    FOREIGN KEY (application_id) REFERENCES application(id)
)