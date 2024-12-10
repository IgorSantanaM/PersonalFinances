import styled from 'styled-components';
import {Link} from 'react-router-dom';

export const Header = styled.header`
  display: flex;
  align-items: center;
  justify-content: space-between;
  margin: 50px 0; 

  div{
    display: flex;
    align-items: center; 
  }
`
export const Next = styled(Link)`
  display:flex;
  align-items: center;
  text-decoration: none;
  transition: opacity 0.2s;

  &:hover{
    opacity: 0.7;
  }
  div{
    text-align: right;
    margin-right: 10px;

    span{
      font-size: 12px;
      color: #999;
    }
  }

`
export const Previous = styled(Link)`
  display:flex;
  align-items: center;
  text-decoration: none;
  transition: opacity 0.2s;

  &:hover{
    opacity: 0.7;
  }
  div{
    text-align: right;
    margin-right: 10px;

    span{
      font-size: 12px;
      color: #999;
    }
  }
`

export const Title = styled.h1`
`;

export const IconWrapper = styled.div`
  display: flex;
  align-items: center;
  justify-content: center;
  background-color: #e6f4e6; 
  border-radius: 50%;
  padding: 10px;
`;