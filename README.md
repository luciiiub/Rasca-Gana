# Rasca-Gana

A scratch card mini-game where the player reveals a hidden reward by scratching the card with the mouse.

When the card is created, a reward is selected at random using weighted probabilities. Each reward has an associated sprite and monetary value, which is hidden behind the card’s front layer.

As the player scratches the card, mask objects are spawned to progressively reveal the reward. Once a defined percentage of the card is uncovered, the card is fully revealed and the result is processed.

If the revealed card contains a reward, the player gains the corresponding amount of money. If no reward is present, the player loses sanity. After the result, a New Card button appears, allowing the player to generate another scratch card.

The system manages reward selection, visual scaling, scratch progress detection, and UI flow, ensuring the reward is only granted once per card.
