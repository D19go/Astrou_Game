# Astrou_Game (Nova Terra)

Jogo 3D de exploração espacial desenvolvido na **Unity**, em que o jogador controla um astronauta que percorre o espaço e planetas, cumpre missões e enfrenta inimigos.

> **Status:** projeto de estudo/portfólio, iniciado durante o curso técnico em Programação de Jogos Digitais (Senac São Carlos).



## Sistemas implementados (scripts em C#)

Levantados a partir do código em `Assets/script`:

- **Cenas:** Menu, Instruções, Espaço, Planeta 1 e local de partida, com teletransporte entre planeta e espaço (`TpPlanet`, `TpSpace`, `TelePortal`).
- **Jogador:** movimentação, câmeras em primeira e terceira pessoa, vida e habilidades (`MoviPlayer`, `Cam1P`, `AstronautThirdPersonCamera`, `VidaPlayer`, `Habilidades`).
- **Inimigos:** patrulha, perseguição ao jogador, ataque à distância e corpo a corpo, chefe e sistema de dano (`AiPatrol`, `PerseguePlayer`, `AtkRange`, `DanoEnemy`, `CampoDectBoss`).
- **Veículos:** nave, carro, moto e tanque (`NaveCtrl`, `CarController`, `motoController`, `TankiCTRL`).
- **Inventário:** itens coletáveis, baú e menus de inventário (`inventarioCTRL`, `Bau_Inv`, `coletavel`, `DropItem`).
- **Missões:** sistema de missões geral e por planeta (`Missoes`, `MissoesGeral`, `MissoesP1`).
- **Interface:** menu, tela de instruções e notificações em tela (`MenuPainel`, `telaInstr`, `ToastNotification`).

## Controles

As imagens de tutorial do projeto indicam as teclas **W, A, S, D, Shift, Espaço, F e G**.

## Como executar

1. Instale a **Unity 2023.1.13f1** (via Unity Hub).
2. Clone o repositório e abra a pasta do projeto pelo Unity Hub.
3. Abra a cena `Assets/Scenes/Menu.unity` e clique em **Play**.

## Tecnologias

- Unity 2023.1.13f1
- C#

## Créditos de assets de terceiros

Este projeto usa pacotes de terceiros, que pertencem aos seus respectivos autores:
Polygonal Metalon, Low Poly Alien World, LOWPOLY-Spaceship, Stylized Astronaut, Toast Notification Message e Unity Particle Pack.

## Autor

**Diogo da Silva Costa** — [GitHub](https://github.com/D19go)
