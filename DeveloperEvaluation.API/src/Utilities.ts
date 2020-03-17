import { OpenCharacter, CloseCharacter, ReservedCharacter } from "./CustomTypes";

const hasValue = (item: any): boolean => item !== undefined && item !== null;

const isOpeningCharacter = (char?: OpenCharacter): boolean => {
	switch (char) {
		case OpenCharacter.Brace:
		case OpenCharacter.Bracket:
		case OpenCharacter.Paren:
			return true;
		default:
			return false;
	}
};

const isClosingCharacter = (char?: CloseCharacter): boolean => {
	switch (char) {
		case CloseCharacter.Brace:
		case CloseCharacter.Bracket:
		case CloseCharacter.Paren:
			return true;
		default:
			return false;
	}
};

const isReserverdCharacter = (char?: ReservedCharacter): boolean => hasValue(char);

const isValidClosure = (openChar: ReservedCharacter, closeChar: ReservedCharacter): boolean => {
	switch (openChar) {
		default:
			return false;
		case OpenCharacter.Brace:
			return closeChar === CloseCharacter.Brace;
		case OpenCharacter.Bracket:
			return closeChar === CloseCharacter.Bracket;
		case OpenCharacter.Paren:
			return closeChar === CloseCharacter.Paren;
	}
}

export const isProperlyClosed = (lexicalExpression: string): boolean => {
	if (lexicalExpression === undefined || lexicalExpression === null || lexicalExpression === '')
		return true;

	const characterStack: ReservedCharacter[] = [];
	var index: number = 0;

	for (; index < lexicalExpression.length; index++) {
		var currentCharacter = lexicalExpression[index] as ReservedCharacter;

		if (!isReserverdCharacter(currentCharacter))
			continue;

		if (isOpeningCharacter(currentCharacter as OpenCharacter)) {
			characterStack.push(currentCharacter);
			continue;
		}

		if (isClosingCharacter(currentCharacter as CloseCharacter)) {
			var topOfStack = characterStack.pop();

			if (!isValidClosure(topOfStack, currentCharacter))
				return false;
		}
	}

	return characterStack.length === 0;
};