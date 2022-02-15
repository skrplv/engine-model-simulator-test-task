# engine-model-simulator-test-task. Тестовое задание для компании Forward
Язык программирования:  C# или С++ Среда выполнения: Microsoft Visual Studio Время выполнения: 4 часа (время указано для ориентира, оно не является ограничением; главное – качество выполнения)
# Задача:
Необходимо разработать консольное приложение, которое рассчитывает и выводит время, которое пройдет от старта двигателя внутреннего сгорания до момента его перегрева, в зависимости от заданной температуры окружающей среды. Приложение должно принимать с консоли пользовательский ввод температуры окружающей среды в градусах Цельсия, и выводить на консоль время до перегрева в секундах. Рассчитывать время точно, аналитическим путем не нужно, интересует получение этого времени методом симуляции (разумеется, таким образом время будет вычислено с определенной погрешностью). Приложение должно состоять из трех логических блоков:
# Симуляция двигателя внутреннего сгорания
Требуется упрощенно симулировать изменение скорости вращения коленвала и температуры охлаждающей жидкости двигателя, работающего без нагрузки, с течением времени. Входные параметры: • Момент инерции двигателя I (кг∙м∙м) • Кусочно-линейная зависимость крутящего момента M, вырабатываемого двигателем, от скорости вращения коленвала V (крутящий момент в Н∙м, скорость вращения в радиан/сек): • Температура перегрева Tперегрева (C цельсия) • Коэффициент зависимости скорости нагрева от крутящего момента HM (𝐶 цельсия / 𝐻∙𝑚∙сек) • Коэффициент зависимости скорости нагрева от скорости вращения коленвала HV (𝐶 цельсия∙сек / рад ∙ рад) • Коэффициент зависимости скорости охлаждения от температуры двигателя и окружающей среды C (1 / сек) Так как двигатель работает без нагрузки, то весь вырабатываемый момент идет на раскрутку коленвала, и его ускорение вычисляется просто: 𝒂 = 𝑴 / 𝐈 Специальной логики старта двигателя не требуется. Считаем, что при старте он просто начинает вырабатывать крутящий момент по заданному графику начиная с нулевой скорости вращения. Скорость нагрева двигателя рассчитывать как VH = M × HM + V×V × HV (𝐶 цельсия/сек) Скорость охлаждения двигателя рассчитывать как VC = C × (Tсреды - Тдвигателя) (𝐶 цельсия /сек) Температура двигателя до момента старта должна равняться температуре окружающей среды. Нагрев и охлаждение, рассчитанные по формулам выше, действуют на двигатель постоянно, одновременно и независимо друг от друга.
# Логика тестирования двигателя на перегрев
Требуется реализовать «тестовый стенд», исследующий поданный на вход двигатель. Тестовый стенд должен включать двигатель, следить за его температурой, и в момент перегрева прекращать тест и возвращать время, прошедшее с момента старта до перегрева. Расчет симуляции двигателя не должен производиться в реальном времени. Необходимо использовать модельное время, чтобы ожидание результатов работы программы не было продолжительным.
# Консольный ввод-вывод, задание исходных данных и запуск теста
Эта часть приложения содержит точку входа, и должна обеспечивать весь ввод/вывод на консоль, а так же задание всех исходных данных и запуск теста двигателя. Все исходные данные, кроме температуры окружающей среды, нужно задать в коде или в конфигурационном файле: I = 10 M = { 20, 75, 100, 105, 75, 0 } при V = { 0, 75, 150, 200, 250, 300 } соответственно Tперегрева = 110 HM = 0.01 HV = 0.0001 C = 0.1 Температура окружающей среды вводится пользователем с клавиатуры, после запуска приложения.
# Критерии оценки:
Выполненное задание будет оцениваться по следующим критериям:
- Корректность работы.
Приложение должно выдавать корректный результат на различных входных данных, не должно быть вылетов и зависаний.
- Архитектура.
Простота расширения функционала: добавление новых типов двигателей, в том числе не внутреннего сгорания, новых типов тестов. Простота изменения входных данных тестов.
- Оформление.
Читаемость кода, организация файлов и папок приложения. В качестве результата необходимо выслать архив, содержащий проект MS Visual Studio и файлы исходного кода (либо ссылку на скачивание архива).
