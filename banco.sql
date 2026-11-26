
-- Criando o banco de dados
CREATE DATABASE IF NOT EXISTS sustentabilidade;

-- Escolhendo o banco
USE sustentabilidade;

-- Tabela de categorias
CREATE TABLE IF NOT EXISTS categoria (
    id_categoria INT AUTO_INCREMENT PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL,
    Descricao TEXT
);

-- Tabela dos residuos
CREATE TABLE IF NOT EXISTS residuo (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL,
    Descricao TEXT,
    Reciclavel BOOLEAN NOT NULL,
    Orientacao TEXT,
    IdCategoria INT,

    FOREIGN KEY (IdCategoria) REFERENCES categoria(id_categoria)
);

-- Tabela dos pontos de coleta
CREATE TABLE IF NOT EXISTS ponto_coleta (
    id_ponto INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    endereco VARCHAR(200) NOT NULL,
    bairro VARCHAR(100),
    cidade VARCHAR(100),
    telefone VARCHAR(20),
    horario_funcionamento VARCHAR(100)
);

-- Essa tabela faz a ligacao entre residuos e pontos
CREATE TABLE IF NOT EXISTS residuo_ponto (
    id INT AUTO_INCREMENT PRIMARY KEY,
    id_residuo INT NOT NULL,
    id_ponto INT NOT NULL,

    FOREIGN KEY (id_residuo) REFERENCES residuo(Id),
    FOREIGN KEY (id_ponto) REFERENCES ponto_coleta(id_ponto)
);

SHOW TABLES;

USE sustentabilidade;

-- Cadastrando as categorias
INSERT INTO categoria (Nome, Descricao) VALUES
('Papel', 'Materiais feitos de papel'),
('Plastico', 'Materiais feitos de plastico'),
('Vidro', 'Materiais feitos de vidro'),
('Metal', 'Materiais feitos de metal'),
('Organico', 'Restos de alimentos e plantas');

-- Cadastrando alguns residuos
INSERT INTO residuo
(Nome, Descricao, Reciclavel, Orientacao, IdCategoria)
VALUES
('Papelão', 'Caixas de papelao', 1, 'Dobrar e colocar na coleta de papel', 1),
('Jornal', 'Folhas de jornal usadas', 1, 'Manter seco e limpo', 1),
('Garrafa PET', 'Garrafas de plastico', 1, 'Esvaziar e encaminhar para reciclagem', 2),
('Sacola plastica', 'Sacolas de mercado', 1, 'Juntar e levar para coleta de plastico', 2),
('Pote de vidro', 'Potes de vidro usados', 1, 'Lavar antes de descartar', 3),
('Garrafa de vidro', 'Garrafas de vidro', 1, 'Separar dos outros materiais', 3),
('Lata de aluminio', 'Latas de refrigerante', 1, 'Esvaziar antes de descartar', 4),
('Lata de aço', 'Latas de alimentos', 1, 'Lavar antes de descartar', 4),
('Casca de banana', 'Restos de frutas', 0, 'Pode ser utilizada na compostagem', 5),
('Restos de comida', 'Sobras de alimentos', 0, 'Separar para compostagem', 5);

-- Mostrando os residuos cadastrados
SELECT * FROM residuo;

SELECT * FROM categoria;

-- Cadastrando os pontos de coleta
INSERT INTO ponto_coleta
(nome, endereco, bairro, cidade, telefone, horario_funcionamento)
VALUES
('EcoPonto Central', 'Rua das Flores, 100', 'Centro', 'Palhoca', '(48) 3000-1001', '08:00 às 17:00'),
('Coleta Verde', 'Rua das Palmeiras, 250', 'Ponte do Imaruim', 'Palhoca', '(48) 3000-1002', '08:00 às 18:00'),
('Recicla Mais', 'Avenida Brasil, 300', 'Pagani', 'Palhoca', '(48) 3000-1003', '09:00 às 17:00'),
('Ponto Sustentavel', 'Rua das Acacias, 150', 'Centro', 'Palhoca', '(48) 3000-1004', '08:00 às 16:00'),
('EcoReciclagem', 'Rua do Meio, 400', 'Bela Vista', 'Palhoca', '(48) 3000-1005', '08:00 às 17:00');

SELECT * FROM ponto_coleta;

-- Ligando residuos aos pontos de coleta
INSERT INTO residuo_ponto (id_residuo, id_ponto)
VALUES
(1, 1),
(2, 1),
(3, 2),
(4, 2),
(5, 3),
(6, 3),
(7, 4),
(8, 4),
(9, 5),
(10, 5);

SELECT * FROM residuo_ponto;

-- INNER JOIN entre residuos e categorias
SELECT
    residuo.Nome AS residuo,
    categoria.Nome AS categoria
FROM residuo
INNER JOIN categoria
ON residuo.IdCategoria = categoria.id_categoria;

-- INNER JOIN entre residuos e pontos de coleta
SELECT
    residuo.Nome AS residuo,
    ponto_coleta.nome AS ponto_coleta
FROM residuo
INNER JOIN residuo_ponto
ON residuo.Id = residuo_ponto.id_residuo
INNER JOIN ponto_coleta
ON residuo_ponto.id_ponto = ponto_coleta.id_ponto;

-- LEFT JOIN entre residuos e pontos de coleta
SELECT
    residuo.Nome AS residuo,
    ponto_coleta.nome AS ponto_coleta
FROM residuo
LEFT JOIN residuo_ponto
ON residuo.Id = residuo_ponto.id_residuo
LEFT JOIN ponto_coleta
ON residuo_ponto.id_ponto = ponto_coleta.id_ponto;

-- Consulta completa
SELECT
    residuo.Nome AS residuo,
    categoria.Nome AS categoria,
    ponto_coleta.nome AS ponto_coleta
FROM residuo
INNER JOIN categoria
ON residuo.IdCategoria = categoria.id_categoria
INNER JOIN residuo_ponto
ON residuo.Id = residuo_ponto.id_residuo
INNER JOIN ponto_coleta
ON residuo_ponto.id_ponto = ponto_coleta.id_ponto;

-- Mostrando residuos reciclaveis e nao reciclaveis
SELECT
    Nome AS residuo,
    Reciclavel,
    Orientacao
FROM residuo
ORDER BY Reciclavel DESC;

-- Quantidade de residuos por categoria
SELECT
    categoria.Nome AS categoria,
    COUNT(residuo.Id) AS quantidade_residuos
FROM categoria
LEFT JOIN residuo
ON categoria.id_categoria = residuo.IdCategoria
GROUP BY categoria.Nome;

-- Quantidade de residuos reciclaveis e nao reciclaveis
SELECT
    Reciclavel,
    COUNT(*) AS quantidade
FROM residuo
GROUP BY Reciclavel;

-- Quantidade de residuos por ponto de coleta
SELECT
    ponto_coleta.nome AS ponto_coleta,
    COUNT(residuo_ponto.id_residuo) AS quantidade_residuos
FROM ponto_coleta
LEFT JOIN residuo_ponto
ON ponto_coleta.id_ponto = residuo_ponto.id_ponto
GROUP BY ponto_coleta.nome
ORDER BY quantidade_residuos DESC;

-- Atualizando um residuo
UPDATE residuo
SET Descricao = 'Caixas de papelão usadas'
WHERE Id = 1;

SELECT * FROM residuo
WHERE Id = 1;

-- Inserindo um residuo de teste
INSERT INTO residuo (Nome, Descricao, Reciclavel, Orientacao, IdCategoria)
VALUES ('Residuo de teste', 'Registro temporario', 1, 'Teste de exclusao', 1);

-- Excluindo o residuo de teste


-- Conferindo a exclusao
SELECT Id, Nome
FROM residuo
WHERE Nome = 'Residuo de teste';

