import React from 'react';
import {TfiCalendar, TfiClip} from 'react-icons/tfi';
import { MdMoreHoriz, MdNavigateNext, MdAccountBalance } from "react-icons/md";
import { GiWallet, GiTwoCoins } from "react-icons/gi";
import Link from 'react-router-dom'


import {Container, Header, Title, IconWrapper} from './styles'
export default function Home(){

    return(
        <>
            <Header>
                <IconWrapper>
                    <GiWallet size={26} color="green" />
                </IconWrapper>
                <Title>Welcome to Homeasy</Title>
                <button type="button" to="/step">
                    <MdNavigateNext size={25} color="black" />
                </button>
                <p>Next</p>
            </Header>

            <Container>
                <p>Your tool to control all your accounts independently, with an optimised menu to visualise your data</p>
                
                <div>
                    <MdAccountBalance size={20} color="black"/>
                    <strong to="/balances">Balances</strong>
                    <p>The balance of all youraccounts at a glance!</p>
                </div>
                
                <div>
                    <TfiClip size={20} color="black"/>
                    <strong to="/summary">Summary</strong>
                    <p>Here you can see a basic report of movements and budgets for the selected month.</p>
                </div>
                
                <div>
                    <TfiCalendar size={20} color="black"/>
                    <strong to="/calendar">Calendar</strong>
                    <p>A calendar to view payment reminders of each account.</p>
                </div>
                
                <div>
                    <GiTwoCoins size={20} color="black"/>
                    <strong to="/movements">Movements</strong>
                    <p>List of all movements for the month for each account.</p>
                </div>
                
                <div>
                    <MdMoreHoriz size={20} color="black"/>
                    <strong to="/menu">More</strong>
                    <p>Easy access to the management of all your data, tools and settings</p>
                </div>

                {/* TODO: ADD THE SYNC BUTTON */}
                <h2>Click the Next button as soon as your ready to set up your Homeasy accounts, it will only take a few minutes</h2>
            </Container>
        </>
    )
}