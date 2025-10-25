
-- TURNERO lógica conceptual

-- Paciente ( 1 Paciente pide una Solicitud o varias )
    -- Solicitud ( La Solicitud es generada por el sistema y se evalua si se asigna el Turno )
        -- Turno ( El turno se registra solo y solo si hay disponibilidad de Medico )
            -- Medico ( FK de Turno )
                -- Especialidad ( FK de Medico )
            -- Consultorio ( FK de Turno )


CREATE DATABASE api_db_turnero;


-- Tabla de pacientes
CREATE TABLE Paciente (
    id_paciente INT PRIMARY KEY IDENTITY(1,1),
    nombre VARCHAR(100),
    email VARCHAR(100),
    telefono VARCHAR(20),
    fecha_nacimiento DATE
);

-- Tabla de especialidades
CREATE TABLE Especialidad (
    id_especialidad INT PRIMARY KEY IDENTITY(1,1),
    descripcion VARCHAR(100)
);

-- Inserts de especialidades
INSERT INTO Especialidad(descripcion) VALUES 
('Odontología'),
('Pediatría'),
('Cirujano'),
('Enfermería');

-- Tabla de médicos
CREATE TABLE Medico (
    id_medico INT PRIMARY KEY IDENTITY(1,1),
    nombre VARCHAR(100),
    email VARCHAR(100),
    id_especialidad INT FOREIGN KEY REFERENCES Especialidad(id_especialidad)
);

-- Inserts de médicos
INSERT INTO Medico(nombre, email, id_especialidad) VALUES
('Jose Migrañas', 'jose@gmail.com', 1),
('Angela Leiva', 'angela@gmail.com', 2),
('Juan Genitales', 'juan@gmail.com', 3),
('Carla Guardia', 'carla@gmail.com', 4);

-- Tabla de consultorios
CREATE TABLE Consultorio (
    id_consultorio INT PRIMARY KEY IDENTITY(1,1),
    direccion VARCHAR(150)
);

-- Inserts de consultorios
INSERT INTO Consultorio(direccion) VALUES
('Calle falsa 123'),
('Av. siempre viva 0'),
('Buenos Aires 012');

-- Tabla de Usuarios 
CREATE TABLE Usuario (
    id_usuario INT PRIMARY KEY IDENTITY(1,1),
    username VARCHAR(50) NOT NULL UNIQUE,
    password VARCHAR(255) NOT NULL,
    email VARCHAR(100)
);

-- Inserts de usuarios
INSERT INTO Usuario (username, password, email) VALUES
('admin', 'admin123', 'admin@turnero.com'),
('usuario1', 'clave123', 'usuario1@gmail.com');



-- Tabla de turnos
CREATE TABLE Turno (
    id_turno INT PRIMARY KEY IDENTITY(1,1),
    fecha_turno DATETIME,
    estado VARCHAR(50),
    id_paciente INT FOREIGN KEY REFERENCES Paciente(id_paciente),
    id_medico INT FOREIGN KEY REFERENCES Medico(id_medico),
    id_consultorio INT FOREIGN KEY REFERENCES Consultorio(id_consultorio),
    id_usuario INT FOREIGN KEY REFERENCES Usuario(id_usuario)
);