-- -- Criando o banco de dados
 
-- -- Escolhendo o banco
-- USE sustentabilidade;
 
-- -- Tabela de categorias
-- CREATE TABLE categoria (
--     id_categoria INT AUTO_INCREMENT PRIMARY KEY,
--     nome VARCHAR(100) NOT NULL,
--     descricao TEXT
-- );
 
-- -- Tabela dos residuos
-- CREATE TABLE residuo (
--     id_residuo INT AUTO_INCREMENT PRIMARY KEY,
--     nome VARCHAR(100) NOT NULL,
--     descricao TEXT,
--     reciclavel BOOLEAN NOT NULL,
--     orientacao TEXT,
--     id_categoria INT,
 
--     FOREIGN KEY (id_categoria) REFERENCES categoria(id_categoria)
-- );
 
-- -- Tabela dos pontos de coleta
-- CREATE TABLE ponto_coleta (
--     id_ponto INT AUTO_INCREMENT PRIMARY KEY,
--     nome VARCHAR(100) NOT NULL,
--     endereco VARCHAR(200) NOT NULL,
--     bairro VARCHAR(100),
--     cidade VARCHAR(100),
--     telefone VARCHAR(20),
--     horario_funcionamento VARCHAR(100)
-- );
 
-- -- Essa tabela faz a ligaçao entre residuos e pontos
-- CREATE TABLE residuo_ponto (
--     id INT AUTO_INCREMENT PRIMARY KEY,
--     id_residuo INT NOT NULL,
--     id_ponto INT NOT NULL,
 
--     FOREIGN KEY (id_residuo) REFERENCES residuo(id_residuo),
--     FOREIGN KEY (id_ponto) REFERENCES ponto_coleta(id_ponto)
-- );
 
-- SHOW TABLES;
 
-- USE sustentabilidade;
 
-- INSERT INTO categoria (nome, descricao) VALUES
-- ('Papel', 'Materiais feitos de papel'),
-- ('Plastico', 'Materiais feitos de plastico'),
-- ('Vidro', 'Materiais feitos de vidro'),
-- ('Metal', 'Materiais feitos de metal'),
-- ('Organico', 'Restos de alimentos e plantas');
 
-- -- Cadastrando alguns residuos
 
-- INSERT INTO residuo
-- (nome, descricao, reciclavel, orientacao, id_categoria)
-- VALUES
 
-- ('Papelão', 'Caixas de papelao', 1, 'Dobrar e colocar na coleta de papel', 1),
 
-- ('Jornal', 'Folhas de jornal usadas', 1, 'Manter seco e limpo', 1),
 
-- ('Garrafa PET', 'Garrafas de plastico', 1, 'Esvaziar e encaminhar para reciclagem', 2),
 
-- ('Sacola plastica', 'Sacolas de mercado', 1, 'Juntar e levar para coleta de plastico', 2),
 
-- ('Pote de vidro', 'Potes de vidro usados', 1, 'Lavar antes de descartar', 3),
 
-- ('Garrafa de vidro', 'Garrafas de vidro', 1, 'Separar dos outros materiais', 3),
 
-- ('Lata de aluminio', 'Latas de refrigerante', 1, 'Esvaziar antes de descartar', 4),
 
-- ('Lata de aço', 'Latas de alimentos', 1, 'Lavar antes de descartar', 4),
 
-- ('Casca de banana', 'Restos de frutas', 0, 'Pode ser utilizada na compostagem', 5),
 
-- ('Restos de comida', 'Sobras de alimentos', 0, 'Separar para compostagem', 5);
 
-- -- Mostrando os residuos cadastrados
-- SELECT * FROM residuo;

-- SELECT * FROM categoria;

-- INSERT INTO ponto_coleta
-- (nome, endereco, bairro, cidade, telefone, horario_funcionamento)
-- VALUES
-- ('EcoPonto Central', 'Rua das Flores, 100', 'Centro', 'Palhoca', '(48) 3000-1001', '08:00 às 17:00'),
-- ('Coleta Verde', 'Rua das Palmeiras, 250', 'Ponte do Imaruim', 'Palhoca', '(48) 3000-1002', '08:00 às 18:00'),
-- ('Recicla Mais', 'Avenida Brasil, 300', 'Pagani', 'Palhoca', '(48) 3000-1003', '09:00 às 17:00'),
-- ('Ponto Sustentavel', 'Rua das Acacias, 150', 'Centro', 'Palhoca', '(48) 3000-1004', '08:00 às 16:00'),
-- ('EcoReciclagem', 'Rua do Meio, 400', 'Bela Vista', 'Palhoca', '(48) 3000-1005', '08:00 às 17:00');

-- SELECT * FROM ponto_coleta;

-- INSERT INTO residuo_ponto (id_residuo, id_ponto)
-- VALUES
-- (1, 1),
-- (2, 1),
-- (3, 2),
-- (4, 2),
-- (5, 3),
-- (6, 3),
-- (7, 4),
-- (8, 4),
-- (9, 5),
-- (10, 5);

-- SELECT * FROM residuo_ponto;

-- SELECT
--     residuo.nome AS residuo,
--     categoria.nome AS categoria
-- FROM residuo
-- INNER JOIN categoria
-- ON residuo.id_categoria = categoria.id_categoria;

-- SELECT
--     residuo.nome AS residuo,
--     ponto_coleta.nome AS ponto_coleta
-- FROM residuo
-- INNER JOIN residuo_ponto
-- ON residuo.id_residuo = residuo_ponto.id_residuo
-- INNER JOIN ponto_coleta
-- ON residuo_ponto.id_ponto = ponto_coleta.id_ponto;

-- SELECT
--     residuo.nome AS residuo,
--     ponto_coleta.nome AS ponto_coleta
-- FROM residuo
-- LEFT JOIN residuo_ponto
-- ON residuo.id_residuo = residuo_ponto.id_residuo
-- LEFT JOIN ponto_coleta
-- ON residuo_ponto.id_ponto = ponto_coleta.id_ponto;

-- SELECT
--     residuo.nome AS residuo,
--     categoria.nome AS categoria,
--     ponto_coleta.nome AS ponto_coleta
-- FROM residuo
-- INNER JOIN categoria
-- ON residuo.id_categoria = categoria.id_categoria
-- INNER JOIN residuo_ponto
-- ON residuo.id_residuo = residuo_ponto.id_residuo
-- INNER JOIN ponto_coleta
-- ON residuo_ponto.id_ponto = ponto_coleta.id_ponto;

-- SELECT
--     nome AS residuo,
--     reciclavel,
--     orientacao
-- FROM residuo
-- ORDER BY reciclavel DESC;

-- SELECT
--     categoria.nome AS categoria,
--     COUNT(residuo.id_residuo) AS quantidade_residuos
-- FROM categoria
-- LEFT JOIN residuo
-- ON categoria.id_categoria = residuo.id_categoria
-- GROUP BY categoria.nome;

-- SELECT
--     reciclavel,
--     COUNT(*) AS quantidade
-- FROM residuo
-- GROUP BY reciclavel;

-- SELECT
--     ponto_coleta.nome AS ponto_coleta,
--     COUNT(residuo_ponto.id_residuo) AS quantidade_residuos
-- FROM ponto_coleta
-- LEFT JOIN residuo_ponto
-- ON ponto_coleta.id_ponto = residuo_ponto.id_ponto
-- GROUP BY ponto_coleta.nome
-- ORDER BY quantidade_residuos DESC;

-- UPDATE residuo
-- SET descricao = 'Caixas de papelão usadas'
-- WHERE id_residuo = 1;

-- SELECT * FROM residuo
-- WHERE id_residuo = 1;

-- INSERT INTO residuo (nome, descricao, reciclavel, orientacao, id_categoria)
-- VALUES ('Residuo de teste', 'Registro temporario', 1, 'Teste de exclusao', 1);

-- DELETE FROM residuo
-- WHERE nome = 'Residuo de teste';

-- SELECT id_residuo, nome
-- FROM residuo
-- WHERE nome = 'Residuo de teste';

-- DELETE FROM residuo
-- WHERE id_residuo = 11;