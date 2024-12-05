import styled from 'styled-components';

export const Header = styled.header`
  display: flex;
  align-items: center;
  justify-content: center;
  margin-top: 20px;
  padding-bottom: 20px; 
`

export const Title = styled.h1`
  font-size: 24px;
  color: #003366; 
  margin-left: 10px;
`;

export const IconWrapper = styled.div`
  display: flex;
  align-items: center;
  justify-content: center;
  background-color: #e6f4e6; 
  border-radius: 50%;
  padding: 10px;
`;

export const Container = styled.div`
    color: black;
    border: solid whitesmoke 1px;
    padding: 5px;
    strong{
        color: rgb(23, 129, 255);
    }
    svg{
        padding-right: 5px;
    }
    div{
        padding: 10px;
    }
`;