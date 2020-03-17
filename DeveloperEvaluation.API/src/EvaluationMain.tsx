import * as React from 'react';
import * as ReactDOM from "react-dom";
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { Container, FormGroup, FormControl, TextField, Button } from '@material-ui/core';
import { Alert } from '@material-ui/lab';
import { isProperlyClosed } from './Utilities';

interface EvaluationState {
	isValid?: boolean;
	lexicalExpression: string;
}

export class EvaluationMain extends React.Component<{}, EvaluationState> {
	constructor(props: {}) {
		super(props);

		this.state = { lexicalExpression: '' };

		this.onTextChanged = this.onTextChanged.bind(this);
		this.onValidateExpression = this.onValidateExpression.bind(this);
		this.getValidationResponse = this.getValidationResponse.bind(this);
	}

	onTextChanged(evt: React.ChangeEvent<HTMLTextAreaElement>) {
		this.setState({ lexicalExpression: evt.target.value });
	}

	onValidateExpression() {
		this.setState({ isValid: isProperlyClosed(this.state.lexicalExpression) });
	}

	getValidationResponse(isValid?: boolean) {
		if (isValid === undefined || isValid === null)
			return <span />;
		else if (isValid === false)
			return <Alert severity="error">Doesn't quite pass muster, try again!</Alert>;
		
		return <Alert severity="success">Parses like a charm!</Alert>;			 
	}

	render() {
		return <Container>
			<FormGroup>
				<FormControl>
					<TextField
						className="col-6"
						id="lexical-input"
						label="Input Lexical String"
						multiline={true}
						rows={4}
						variant="outlined"
						onChange={this.onTextChanged}
					/>
					<Button
						className="col-2"
						variant="contained"
						color="primary"
						onClick={this.onValidateExpression}
					>
						Check Expression
					</Button>
				</FormControl>
				<FormControl fullWidth={true}>{this.getValidationResponse(this.state.isValid)}</FormControl>
			</FormGroup>
		</Container>
	}
}


var ContainerElement = document.getElementById("ClosureContainer");
ReactDOM.render(<EvaluationMain />, ContainerElement);