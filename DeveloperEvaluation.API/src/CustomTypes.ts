export const enum OpenCharacter {
	Bracket = '[',
	Paren = '(',
	Brace = '{'
};

export const enum CloseCharacter {
	Bracket = ']',
	Paren = ')',
	Brace = '}'
}

export type ReservedCharacter = OpenCharacter | CloseCharacter;