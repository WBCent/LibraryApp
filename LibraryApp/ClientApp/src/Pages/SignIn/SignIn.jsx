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
    
    
    
    return (
        <Container>
            <Card variant="outlined">
                <Typography variant="h5">Sign In</Typography>
                <FormLabel>Username</FormLabel>
                <TextField id="username" name="username" value={signInValues.username} onChange={handleInputChange} />
                <FormLabel>Password</FormLabel>
                <TextField id="password" name="password" value={signInValues.password} onChange={handleInputChange} />
                <Divider />
                <Typography variant="h5">Sign Up</Typography>
                <FormLabel>Username</FormLabel>
                <TextField id="SUusername" name="username" value={signInValues.username} onChange={handleInputChangeSignUp} />
                <FormLabel>What is your Role</FormLabel>
                <RadioGroup defaultValue="visitor" name="role">
                    <FormControlLabel control={<Radio />} label="Visitor" value="visitor" />
                    <FormControlLabel control={<Radio />} label="Librarian" value="librarian" />
                </RadioGroup>
                <FormLabel>Password</FormLabel>
                <TextField id="SUpassword" name="password" value={signInValues.password} onChange={handleInputChangeSignUp} />
            </Card>
        </Container>
    )
}

export default SignIn;