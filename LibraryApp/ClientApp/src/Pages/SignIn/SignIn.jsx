import {
    Card,
    Container,
    Divider,
    FormLabel,
    TextField,
    Typography,
    Button,
    RadioGroup,
    FormControlLabel, Radio
} from "@mui/material";
import {useState} from "react";

const signIn = {
    username: "",
    password: ""
}

const signUp = {
    username: "",
    role: "",
    password: ""
}

const SignIn = () => {
    const [signInValues, setSignInValues] = useState(signIn);
    const [signUpValues, setSignUpValues] = useState(signUp)
    
    const handleInputChange = (e) => {
        const {name, value} = e.target;
        console.log("Changing", name, value)
        setSignInValues({...signInValues, [name] : value})
    }

    const handleInputChangeSignUp = (e) => {
        const {name, value} = e.target;
        console.log("Changing", name, value)
        setSignUpValues({...signUpValues, [name] : value})
    }
    
    const SubmitSignIn = async () => {
        try {
            let signIn = await fetch(
                'https://localhost:5229/api/Account/login', {
                    method: "POST",
                    body: JSON.stringify(signInValues),
                    headers: {
                        'Content-Type': 'application/json'
                    }
                }
            )
            let signInResponse = await signIn.json();
            console.log(signInResponse);
            emptySignIn();
        } catch(e) {
            console.log(e)
        }
    }
    const SubmitSignUp = async () => {
        try {
            console.log("sending")
            let signUp = await fetch(
                'https://localhost:5229/api/Account/register', {
                    method: "POST",
                    body: JSON.stringify(signInValues),
                    headers: {
                        'Content-Type': 'application/json'
                    }
                }
            )
            let signUpResponse = await signUp.json();
            console.log(signUpResponse);
            empty();
        } catch(e) {
            console.log(e)
        }
    }
    
    const empty = () => {
        setSignUpValues({
            username: "",
            role: "",
            password: ""
        })
    }
    
    const emptySignIn = () => {
        setSignInValues({
            username: "",
            password: ""
        })
    }
    
    return (
        <Container>
            <Card variant="outlined">
                <Typography variant="h5">Sign In</Typography>
                <FormLabel>Username</FormLabel>
                <TextField id="username" name="username" value={signInValues.username} onChange={handleInputChange} />
                <FormLabel>Password</FormLabel>
                <TextField id="password" name="password" value={signInValues.password} onChange={handleInputChange} />
                <Button variant="contained" onClick={SubmitSignIn}>Login</Button>
                <Divider />
                <Typography variant="h5">Sign Up</Typography>
                <FormLabel>Username</FormLabel>
                <TextField id="SUusername" name="username" value={signUpValues.username} onChange={handleInputChangeSignUp} />
                <FormLabel>What is your Role</FormLabel>
                <RadioGroup defaultValue="visitor" name="role" value={signUpValues.role}>
                    <FormControlLabel control={<Radio />} label="Visitor" value="visitor" />
                    <FormControlLabel control={<Radio />} label="Librarian" value="librarian" />
                </RadioGroup>
                <FormLabel>Password</FormLabel>
                <TextField id="SUpassword" name="password" value={signUpValues.password} onChange={handleInputChangeSignUp} />
                <Button variant="contained" onClick={SubmitSignUp}>Sign Up</Button>
            </Card>
        </Container>
    )
}

export default SignIn;