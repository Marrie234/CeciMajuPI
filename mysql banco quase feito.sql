
USE sustentabilidade;

-- Cadastrando os pontos de coleta
INSERT INTO pontos_coleta
(nome, endereco, bairro, cidade, telefone, horario_funcionamento)
VALUES
('Ponto Verde', 'Rua Exemplo, 100', 'Centro', 'Itajai', '47999990001', '08:00 as 18:00'),

('Eco Coleta', 'Avenida Exemplo, 200', 'Centro', 'Itajai', '47999990002', '09:00 as 17:00'),

('Recicla Mais', 'Rua das Flores, 300', 'Jardim', 'Itajai', '47999990003', '08:00 as 17:00');


SELECT * FROM pontos_coleta;

DELETE FROM pontos_coleta
WHERE id_ponto IN (4, 5, 6);

SELECT * FROM pontos_coleta;