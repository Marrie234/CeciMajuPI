CREATE DATABASE IF NOT EXISTS sustentabilidade;

USE sustentabilidade;

CREATE TABLE IF NOT EXISTS categorias (
    id_categoria INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(50) NOT NULL,
    descricao VARCHAR(200)
);

CREATE TABLE IF NOT EXISTS residuos (
    id_residuo INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    descricao VARCHAR(200),
    reciclavel BOOLEAN NOT NULL,
    orientacao VARCHAR(300),
    id_categoria INT NOT NULL,

    FOREIGN KEY (id_categoria)
    REFERENCES categorias(id_categoria)
);


CREATE TABLE IF NOT EXISTS pontos_coleta (
    id_ponto INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    endereco VARCHAR(200) NOT NULL,
    bairro VARCHAR(100),
    cidade VARCHAR(100) NOT NULL,
    telefone VARCHAR(20),
    horario_funcionamento VARCHAR(100)
);

CREATE TABLE IF NOT EXISTS residuos_pontos (
    id INT AUTO_INCREMENT PRIMARY KEY,
    id_residuo INT NOT NULL,
    id_ponto INT NOT NULL,

    FOREIGN KEY (id_residuo)
    REFERENCES residuos(id_residuo),

    FOREIGN KEY (id_ponto)
    REFERENCES pontos_coleta(id_ponto),

    UNIQUE (id_residuo, id_ponto)
);

INSERT INTO categorias (nome, descricao) VALUES
('Papel', 'Materiais feitos de papel e papelão'),
('Plástico', 'Embalagens e objetos de plástico'),
('Vidro', 'Garrafas e recipientes de vidro'),
('Metal', 'Latas e objetos metálicos'),
('Orgânico', 'Restos de alimentos e materiais orgânicos');

INSERT INTO residuos
(nome, descricao, reciclavel, orientacao, id_categoria) VALUES

('Jornal', 'Papel utilizado para impressão de notícias',
TRUE, 'Deve estar limpo e seco.', 1),

('Garrafa PET', 'Garrafa de plástico utilizada para bebidas',
TRUE, 'Esvaziar e amassar antes do descarte.', 2),

('Garrafa de vidro', 'Recipiente de vidro',
TRUE, 'Descartar com cuidado para evitar acidentes.', 3),

('Lata de alumínio', 'Embalagem de bebidas',
TRUE, 'Esvaziar antes de colocar na coleta.', 4),

('Restos de alimentos', 'Sobras de comida',
FALSE, 'Podem ser destinados à compostagem.', 5);

INSERT INTO pontos_coleta
(nome, endereco, bairro, cidade, telefone, horario_funcionamento) VALUES

('Eco Ponto Central', 'Rua das Flores, 100',
'Centro', 'Itajaí', '(47) 3333-1111', '08:00 às 17:00'),

('Coleta Verde', 'Avenida Brasil, 250',
'Fazenda', 'Itajaí', '(47) 3333-2222', '09:00 às 18:00'),

('Recicla Mais', 'Rua do Comércio, 50',
'São João', 'Itajaí', '(47) 3333-3333', '08:00 às 16:00');

INSERT INTO residuos_pontos (id_residuo, id_ponto) VALUES
(1, 1),
(2, 1),
(3, 1),
(4, 2),
(2, 2),
(1, 3),
(4, 3);


SELECT * FROM categorias;

SELECT * FROM residuos;

SELECT * FROM pontos_coleta;

SELECT * FROM residuos_pontos;

SELECT
    residuos.nome AS residuo,
    categorias.nome AS categoria,
    residuos.orientacao
FROM residuos
INNER JOIN categorias
ON residuos.id_categoria = categorias.id_categoria;


SELECT
    pontos_coleta.nome AS ponto,
    residuos.nome AS residuo,
    pontos_coleta.endereco
FROM residuos_pontos
INNER JOIN pontos_coleta
ON residuos_pontos.id_ponto = pontos_coleta.id_ponto
INNER JOIN residuos
ON residuos_pontos.id_residuo = residuos.id_residuo;
