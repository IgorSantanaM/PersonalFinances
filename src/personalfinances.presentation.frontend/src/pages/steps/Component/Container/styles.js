import styled from 'styled-components';
import {Link} from 'react-router-dom';

export const Container = styled.div`
    color: black;
    padding-top: 10px;
    border: 1px solid whitesmoke;

    p{
        margin-bottom: 10px;
    }
`;

export const StepButton = styled(Link)`
    display: flex;
    text-decoration: none;
    padding: 20px;
    align-items: center; 

    button {
        display: block;
        padding: 10px 20px;
    }
`;
