use std::{fs, io, string};
use chrono::Local;
fn main() {
    let tit_0: String = string::String::from("欢迎使用CS 控制台命令");
    info(&tit_0);
    let tit_1 = string::String::from("正在开启Input循环");
    info(&tit_1);
    input();
}

fn input(){
    let mut user_input: String = String::new();
    loop{
        io::stdin().read_line(&mut user_input).expect("Error: Not Input");
        fs::write("order.txt", &user_input);
    }
}

fn info(string: &String){
    println!("[INFO][{}] {}", Local::now(), string)
}
